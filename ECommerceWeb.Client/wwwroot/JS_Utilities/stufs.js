function showSimpleAlert(message) {
    alert(message);
}

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