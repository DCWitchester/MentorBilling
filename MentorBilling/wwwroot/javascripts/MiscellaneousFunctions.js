function focusElement(id) {
    const element = document.getElementById(id);
    element.focus();
};

function removeElementFocus() {
    window.focus();
};

function blurElement(id)
{
    const element = document.getElementById(id);
    element.focus();
};

function getDimensions() {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

function getElementHeight(id) {
    const element = document.getElementById(id).getBoundingClientRect();
    return document.getElementById(id).getBoundingClientRect().height;
};

function getElementWidth(id) {
    const element = document.getElementById(id).getBoundingClientRect();
    return document.getElementById(id).getBoundingClientRect().width;
};

function getElementSize(id) {
    const element = document.getElementById(id).getBoundingClientRect();
    return {
        width: element.width,
        height: element.height
    };
}

function SubmitForm(id) {
    const element = document.getElementById(id);
    element.submit()
}

function ClickButton(id) {
    const element = document.getElementById(id);
    element.click();
}