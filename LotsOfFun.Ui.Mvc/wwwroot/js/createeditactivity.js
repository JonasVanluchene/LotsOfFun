const streetInput = document.querySelector("#streetInput");
const numberInput = document.querySelector("#numberInput");
const unitInput = document.querySelector("#unitInput");
const postalCodeInput = document.querySelector("#postalCodeInput");
const cityInput = document.querySelector("#cityInput");
const locationSelect = document.querySelector("#locationSelect");

const locationData = JSON.parse(locationSelect.dataset.locations);

locationSelect.addEventListener("change", function () {
    const selectedLocationId = parseInt(this.value);
    if (selectedLocationId == 0 || isNaN(selectedLocationId)) {
        clearAddressFields();
        return;
    }
    const selectedLocation = locationData.find(loc => loc.id === selectedLocationId);

    if (selectedLocation) {
        // Populate the address fields
        streetInput.value = selectedLocation.street || '';
        numberInput.value = selectedLocation.number || '';
        unitInput.value = selectedLocation.unit || '';
        postalCodeInput.value = selectedLocation.postalCode || '';
        cityInput.value = selectedLocation.city || '';
    }
})


function clearAddressFields() {
    streetInput.value = '';
    numberInput.value = '';
    unitInput.value = '';
    postalCodeInput.value = '';
    cityInput.value = '';
}