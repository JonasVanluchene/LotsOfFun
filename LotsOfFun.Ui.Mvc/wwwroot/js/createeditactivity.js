// --- Address field references ---
const streetInput = document.querySelector("#streetInput");
const numberInput = document.querySelector("#numberInput");
const unitInput = document.querySelector("#unitInput");
const postalCodeInput = document.querySelector("#postalCodeInput");
const cityInput = document.querySelector("#cityInput");
const locationSelect = document.querySelector("#locationSelect");
const addressFields = [streetInput, numberInput, unitInput, postalCodeInput, cityInput];

const locationData = JSON.parse(locationSelect.dataset.locations);
const isEdit = locationSelect.dataset.isEdit === "true";

// --- Toggle button and section references ---
const addLocationButton = document.querySelector("#addLocationButton");
const knownLocation = document.querySelector("#knownLocation");
const newLocation = document.querySelector("#newLocation");
const saveLocationFormCheck = document.querySelector("#saveLocationForm-Check");


// --- Fill address fields with a given location object ---
function fillAddressFields(location) {
    streetInput.value = location.street || '';
    numberInput.value = location.number || '';
    unitInput.value = location.unit || '';
    postalCodeInput.value = location.postalCode || '';
    cityInput.value = location.city || '';
}

// --- Clear all address fields ---
function clearAddressFields() {
    streetInput.value = '';
    numberInput.value = '';
    unitInput.value = '';
    postalCodeInput.value = '';
    cityInput.value = '';
}


// --- Fill address fields on page load if in edit mode ---
document.addEventListener("DOMContentLoaded", function () {
    const selectedLocationId = parseInt(locationSelect.value);

    if (isEdit && selectedLocationId && !isNaN(selectedLocationId)) {
        const selectedLocation = locationData.find(loc => loc.id === selectedLocationId);
        if (selectedLocation) {
            fillAddressFields(selectedLocation);
        }
    }
});


// --- Fill address fields when a location is selected from dropdown ---
locationSelect.addEventListener("change", function () {
    const selectedLocationId = parseInt(this.value);
    if (selectedLocationId === 0 || isNaN(selectedLocationId)) {
        clearAddressFields();
        return;
    }

    const selectedLocation = locationData.find(loc => loc.id === selectedLocationId);
    if (selectedLocation) {
        fillAddressFields(selectedLocation);
        addressFields.forEach(a => a.setAttribute('readonly', true))
    }
});


// --- Toggle between known location and new location form ---
addLocationButton.addEventListener("click", function () {
    newLocation.classList.toggle("invisible");
    knownLocation.classList.toggle("invisible");
    saveLocationFormCheck.classList.toggle("invisible");

    const isAdding = addLocationButton.textContent.trim() === "Locatie toevoegen";
    addLocationButton.textContent = isAdding ? "Opgeslagen locatie" : "Locatie toevoegen";
    if (isAdding) {
        clearAddressFields();
        addressFields.forEach(a => a.removeAttribute('readonly'));
    }
    else {
        addressFields.forEach(a => a.setAttribute('readonly', true))
    }
});
