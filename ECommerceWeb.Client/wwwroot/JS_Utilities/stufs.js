function showSimpleAlert(message) {
    alert(message);
}

window.addClassById = (elementId, className) => {
    const element = document.getElementById(elementId);
    if (element) {
        element.classList.add(className);
    }
};

window.removeClassById = (elementId, className) => {
    const element = document.getElementById(elementId);
    if (element) {
        element.classList.remove(className);
    }
};

window.setAriaSelectedById = (elementId, value) => {
    const element = document.getElementById(elementId);
    if (element) {
        element.setAttribute('aria-selected', value);
    }
};

window.simulateClickById = (elementId) => {
    const element = document.getElementById(elementId);
    if (element) {
        element.click();
    }
    console.log("click!")
};

window.changeTab = (tabIdToActivate, tabIdToDeactivate) => {
    const tabToActivate = document.getElementById(tabIdToActivate);
    const tabToDeactivate = document.getElementById(tabIdToDeactivate);

    if (tabToDeactivate && tabToActivate) {
        tabToDeactivate.classList.remove('active');
        tabToDeactivate.setAttribute('aria-selected', 'false');

        tabToActivate.classList.add('active');
        tabToActivate.setAttribute('aria-selected', 'true');

        const targetToActivate = document.querySelector(tabToActivate.getAttribute('data-bs-target'));
        const targetToDeactivate = document.querySelector(tabToDeactivate.getAttribute('data-bs-target'));

        if (targetToDeactivate && targetToActivate) {
            targetToDeactivate.classList.remove('show', 'active');
            targetToActivate.classList.add('show', 'active');
        }
    }
    //console.log("click!")
};