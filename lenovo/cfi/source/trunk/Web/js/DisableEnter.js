document.onkeydown = function () {
    if (event.keyCode == 13) {
        if (event.srcElement.tagName.toLowerCase() == "textarea") return;
        if (event.srcElement.tagName.toLowerCase() != "input" || event.srcElement.type.toLowerCase() != "submit") {
            event.returnValue = false;
        }
    }
}
