import { BLACK_COLOUR, WHITE_COLOUR, TYPES, TYPE_COUNT, WHITE_PIXEL, BLACK_PIXEL } from '../Constants.js';
import Canvas from './Canvas.js';

export default class CanvasList {
    width;
    height;
    context;
    original;
    recent;

    constructor(inputImage, canvas) {
        this.width = inputImage.width;
        this.height = inputImage.height;
        this.context = canvas.getContext('2d');
        this.context.drawImage(inputImage, 0, 0);
        this.original = new Canvas(this.context, this.width, this.height);
        this.recent = this.original;
        this.checkers(BLACK_PIXEL, 6);
        this.updateDisplay();
    }

    updateDisplay = () => {
        this.recent.updateDisplay(this.context);
    }

    makeNewRecent = () => {
        const newRecent = new Canvas(this.context, this.width, this.height);
        newRecent.next = this.recent;
        this.recent = newRecent;
        return newRecent;
    }

    checkers = (pixel, skip) => {
        if (skip < 1) {
            return;
        }
        const newRecent = this.makeNewRecent();

        for (let i = 0; i < this.height; i += skip) {
            for (let j = i % 2 || skip / 2 > this.width - 1 ? 0 : Math.floor(skip / 2); j < this.width; j += skip) {
                newRecent.pixels[i * this.width + j] = pixel;
            }
        }
    }

    lines = (pixel, intensity, skip, direction) => {
        if (skip < 1 || direction.length === 0) {
            return;
        }

        const simpleDirection = direction[0].toUpperCase();
        if (!(simpleDirection === 'V' || simpleDirection === 'U' || simpleDirection === 'D' || simpleDirection === 'H' || simpleDirection === 'L' || simpleDirection === 'R')) {
            return;
        }

        const newRecent = this.makeNewRecent();
        let intensityCounter = intensity;

        if (simpleDirection === 'V' || simpleDirection === 'U' || simpleDirection === 'D') {
            for (let i = 0; i < this.width; i += intensityCounter === 0 ? skip : 1) {
                for (let j = 0; j < this.height; ++j) {
                    newRecent[j * this.width + i] = pixel;
                }

                intensityCounter === 0 ? intensityCounter = intensity : --intensityCounter;
            }
        } else {
            for (let i = 0; i < this.height; i += intensityCounter === 0 ? skip : 1) {
                for (let j = 0; j < this.width; ++j) {
                    newRecent[i * this.width + j] = pixel;
                }

                intensityCounter === 0 ? intensityCounter = intensity : --intensityCounter;
            }
        }
    }

    contrast = (makeBrighter, level) => {
        const newRecent = this.makeNewRecent();
        let increment = -20;
        let limit = BLACK_COLOUR;

        if (makeBrighter) {
            increment = 20;
            limit = WHITE_COLOUR;
        }

        const pixelsLength = newRecent.length;
        for (let i = 0; i < pixelsLength; ++i) {
            for (let j = 0; j < TYPE_COUNT - 1; ++j) {
                for (let k = 0; k < level; ++k) {
                    const currColour = newRecent[i][TYPES[j]];
                    newRecent[i][TYPES[j]] = currColour + increment > BLACK_COLOUR && currColour + increment < WHITE_COLOUR ? currColour + increment : limit;
                }
            }
        }
    }

    invert = () => {
        const newRecent = this.makeNewRecent();
        const pixelsLength = newRecent.length;
        for (let i = 0; i < pixelsLength; ++i) {
            for (let j = 0; j < TYPE_COUNT - 1; ++j) {
                newRecent[i][TYPES[j]] = 255 - newRecent[i][TYPES[j]];
            }
        }
    }

    flip = (direction) => {
        if (direction.length === 0) {
            return;
        }

        const simpleDirection = direction[0].toUpperCase();
        if (!(simpleDirection === 'H' || simpleDirection === 'X' || simpleDirection === 'V' || simpleDirection === 'Y')) {
            return;
        }

        const newRecent = this.makeNewRecent();
        if (simpleDirection === 'H' || simpleDirection === 'X') {
            for (let i = 0; i < Math.floor(this.width / 2); ++i) {
                for (let j = 0; j < this.height; ++j) {
                    const tempPixel = newRecent[j * this.width + i];
                    newRecent[j * this.width + i] = newRecent[j * this.width + this.width - 1 - i];
                    newRecent[j * this.width + this.width - 1 - i] = tempPixel;
                }
            }
        } else {
            for (let i = 0; i < Math.floor(this.height / 2); ++i) {
                for (let j = 0; j < this.width; ++j) {
                    const tempPixel = newRecent[i * this.width + j];
                    newRecent[i * this.width + j] = newRecent[(this.height - 1 - i) * this.width + j];
                    newRecent[(this.height - 1 - i) * this.width + j] = tempPixel;
                }
            }
        }
    }

    cropTopLeft = () => {
        const widthMidpoint = Math.floor(this.width / 2);
        const heightMidpoint = Math.floor(this.height / 2);
        const remainingWidth = this.width % widthMidpoint;
        const remainingHeight = this.height % heightMidpoint;

        const newRecent = this.makeNewRecent();
        for (let i = heightMidpoint - 1; i >= 0; --i) {
            for (let j = widthMidpoint - 1; j >= 0; --j) {
                const currPixel = newRecent[i * this.width + j];
                const mapX = this.width - 1 - 2 * (widthMidpoint - 1 - j);
                const mapY = this.height - 1 - 2 * (heightMidpoint - 1 - i);

                for (let k = 0; k < 2; ++k) {
                    for (let l = 0; l < 2; ++l) {
                        newRecent[(mapY - k) * this.width + mapX - l] = currPixel;
                    }
                }
            }
        }

        if (remainingWidth !== 0) {
            this.cleanBorders(remainingWidth, 'L', WHITE_PIXEL);
        }

        if (remainingHeight !== 0) {
            this.cleanBorders(remainingHeight, 'T', WHITE_PIXEL);
        }
    }

    crop = (splitX, splitY, sectionX, sectionY) => {
        if (splitX < 1 || splitY < 1 || sectionX >= splitX || sectionY >= splitY) {
            return;
        }

        if (splitX === 2 && splitY === 2 && sectionX === 0 && sectionY === 0) {
            this.cropTopLeft();
            return;
        }

        const newRecent = this.makeNewRecent();
        const widthMidpoint = Math.floor(this.width / splitX);
        const heightMidpoint = Math.floor(this.height / splitY);
        const remainingWidth = this.width % splitX;
        const remainingHeight = this.height % splitY;

        let sectionPixels = [];
        for (let i = sectionY * heightMidpoint; i < (sectionY + 1) * heightMidpoint; ++i) {
            for (let j = sectionX * widthMidpoint; j < (sectionX + 1) * widthMidpoint; ++j) {
                sectionPixels.push(newRecent[i * this.width + j]);
            }
        }

        for (let i = 0; i < heightMidpoint; ++i) {
            for (let j = 0; j < widthMidpoint; ++j) {
                const currPixel = sectionPixels[i * widthMidpoint + j];

                for (let k = 0; k < splitY; ++k) {
                    for (let l = 0; l < splitX; ++l) {
                        newRecent[(k + i * splitY) * this.width + l + j * splitX] = currPixel;
                    }
                }
            }
        }

        if (remainingWidth !== 0) {
            this.cleanBorders(remainingWidth, 'R', WHITE_PIXEL);
        }

        if (remainingHeight !== 0) {
            this.cleanBorders(remainingHeight, 'B', WHITE_PIXEL);
        }
    }


    duplicate = (splitX, splitY, sectionX, sectionY) => {
        if (splitX < 1 || splitY < 1 || sectionX >= splitX || sectionY >= splitY) {
            return;
        }

        const newRecent = this.makeNewRecent();
        const widthMidpoint = Math.floor(this.width / splitX);
        const heightMidpoint = Math.floor(this.height / splitY);
        const remainingWidth = this.width % splitX;
        const remainingHeight = this.height % splitY;

        for (let i = 0; i < heightMidpoint; ++i) {
            for (let j = 0; j < widthMidpoint; ++j) {
                const currPixel = newRecent[(i + sectionY * heightMidpoint) * this.width + j + sectionX * widthMidpoint];

                for (let k = 0; k < this.height - remainingHeight; k += heightMidpoint) {
                    for (let l = 0; l < this.width - remainingWidth; l += widthMidpoint) {
                        if (k !== sectionY * heightMidpoint || l !== sectionX * widthMidpoint) {
                            newRecent[(i + k) * this.width + j + l] = currPixel;
                        }
                    }
                }
            }
        }

        if (remainingWidth !== 0) {
            this.cleanBorders(remainingWidth, 'R', WHITE_PIXEL);
        }

        if (remainingHeight !== 0) {
            this.cleanBorders(remainingHeight, 'B', WHITE_PIXEL);
        }
    }

    addBorders = (length, pixel, borders) => {
        if (length < 1 || borders.length === 0) {
            return;
        }

        let addToBorder = {
            'T': false,
            'B': false,
            'L': false,
            'R': false
        }

        for (let i = 0; i < borders.length; ++i) {
            const currBorder = borders[i].toUpperCase();
            if (currBorder === 'A') {
                for (let j in addToBorder) {
                    addToBorder[j] = true;
                }
                break;
            }

            if (currBorder in addToBorder) {
                addToBorder[currBorder] = true;
            }
        }

        for (let i in addToBorder) {
            if (addToBorder[i]) {
                this.cleanBorders(length, i, pixel);
            }
        }
    }

    cleanBorders = (remaining, direction, pixel) => {
        if (direction.length === 0) {
            return;
        }

        const simpleDirection = direction[0].toUpperCase();
        if (!(simpleDirection === 'T' || simpleDirection === 'B' || simpleDirection === 'L' || simpleDirection === 'R')) {
            return;
        }

        const newRecent = this.makeNewRecent();
        switch (simpleDirection) {
            case 'T':
                for (let i = 0; i < remaining; ++i) {
                    for (let j = 0; j < this.width; ++j) {
                        newRecent[i * this.width + j] = pixel;
                    }
                }
                break;
            case 'B':
                for (let i = this.height - remaining; i < this.height; ++i) {
                    for (let j = 0; j < this.width; ++j) {
                        newRecent[i * this.width + j] = pixel;
                    }
                }
                break;
            case 'L':
                for (let i = 0; i < this.height; ++i) {
                    for (let j = 0; j < remaining; ++j) {
                        newRecent[i * this.width + j] = pixel;
                    }
                }
                break;
            default:
                for (let i = 0; i < this.height; ++i) {
                    for (let j = this.width - remaining; j < this.width; ++j) {
                        newRecent[i * this.width + j] = pixel;
                    }
                }
        }
    }

    mirror = direction => {
        const simpleDirection = direction[0].toUpperCase();
        if (!(simpleDirection === 'T' || simpleDirection === 'B' || simpleDirection === 'L' || simpleDirection === 'R')) {
            return;
        }

        const newRecent = this.makeNewRecent();
        switch (simpleDirection) {
            case 'T':
                for (let i = 0; i < Math.floor(this.height / 2); ++i) {
                    for (let j = 0; j < this.width; ++j) {
                        newRecent[(this.height - 1 - i) * this.width + j] = newRecent[i * this.width + j];
                    }
                }
                break;
            case 'B':
                for (let i = 0; i < Math.floor(this.height / 2); ++i) {
                    for (let j = 0; j < this.width; ++j) {
                        newRecent[i * this.width + j] = newRecent[(this.height - 1 - i) * this.width + j];
                    }
                }
                break;
            case 'L':
                for (let i = 0; i < Math.floor(this.width / 2); ++i) {
                    for (let j = 0; j < this.height; ++j) {
                        newRecent[j * this.width + this.width - 1 - i] = newRecent[j * this.width + i];
                    }
                }
                break;
            default:
                for (let i = 0; i < Math.floor(this.width / 2); ++i) {
                    for (let j = 0; j < this.height; ++j) {
                        newRecent[j * this.width + i] = newRecent[j * this.width + this.width - 1 - i];
                    }
                }
        }
    }

    blur = (levelX, levelY) => {
        if (levelX < 1 || levelY < 1) {
            return;
        }

        const newRecent = this.makeNewRecent();
        for (let i = 0; i < this.height; i += levelY) {
            for (let j = 0; j < this.width; j += levelX) {
                let sum = {
                    red: 0,
                    green: 0,
                    blue: 0
                };
                let count = 0;

                for (let k = i; k < i + levelY; ++k) {
                    for (let l = j; l < j + levelX; ++l) {
                        if (k >= 0 && k < this.height && l >= 0 && l < this.width) {
                            ++count;
                            for (let m = 0; m < TYPE_COUNT - 1; ++m) {
                                sum[TYPES[m]] += newRecent[k * this.width + l][TYPES[m]];
                            }
                        }
                    }
                }

                const average = {
                    red: sum.red / count,
                    green: sum.green / count,
                    blue: sum.blue / count,
                    alpha: WHITE_COLOUR
                }

                for (let k = i; k < i + levelY; ++k) {
                    for (let l = j; l < j + levelX; ++l) {
                        if (k >= 0 && k < this.height && l >= 0 && l < this.width) {
                            newRecent[k * this.width + l] = average;
                        }
                    }
                }
            }
        }
    }

    reset = () => {
        this.recent = this.original;
    }
}