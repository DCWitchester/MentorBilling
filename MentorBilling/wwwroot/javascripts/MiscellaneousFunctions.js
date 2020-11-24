//#region Element Focus Functions
/**
 * This function will set focus to an element given by its id
 * @param {any} id the form element id
 */
function focusElement(id) {
    const element = document.getElementById(id);
    element.focus();
};

/**
 * This function will remove the focus from an element by giving it to the window
*/
function removeElementFocus() {
    window.focus();
};

/**
 * this will blur the given element
 */
function blurElement(id)
{
    const element = document.getElementById(id);
    element.focus();
};
//#endregion

//#region Element Dimmensions
/**
 * this function will get the given dimmensions of the browser window
 */
function getDimensions() {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

/**
 * this function will get the height of the given elements bounding box
 * @param {any} id the element id
 */
function getElementHeight(id) {
    const element = document.getElementById(id).getBoundingClientRect();
    return document.getElementById(id).getBoundingClientRect().height;
};

/**
 * this function will get the width of the given elements bounding box
 * @param {any} id the element id
 */
function getElementWidth(id) {
    const element = document.getElementById(id).getBoundingClientRect();
    return document.getElementById(id).getBoundingClientRect().width;
};


/**
 * this function will get the size of a given elements bounding box
 * @param {any} id the element id
 */
function getElementSize(id) {
    const element = document.getElementById(id).getBoundingClientRect();
    return {
        width: element.width,
        height: element.height
    };
}
//#endregion

//#region Form Validation
/**
 * this function will submit the given edit form by id
 * *Deprecated*
 * @param {any} id the form id
 */
function SubmitForm(id) {
    const element = document.getElementById(id);
    element.submit()
}

/**
 * this function will submit the given form by calling a click on the valid button
 * @param {any} id
 */
function ClickButton(id) {
    const element = document.getElementById(id);
    element.click();
}

//#endregion

//#region Z-Order
/**
 * this function will send the given element to the background
 * @param {any} id the element id
 */
function sendElementBack(id) {
    document.getElementById(id).style.zIndex = "-1";
}

/**
 * this function will send the given element to the foreground
 * @param {any} id the element id
 */
function bringElementFront(id) {
    document.getElementById(id).style.zIndex = "1";
}
//#region Specific Z-Order
/**
 * this function will send the buyer element to the background
 */
function sendBuyerBack() {
    sendElementBack("buyerElementContainer");
}
/**
 * this function will bring the buyer element to the front
 */
function bringBuyerFront() {
    bringElementFront("buyerElementContainer");
}
//#endregion
//#endregion