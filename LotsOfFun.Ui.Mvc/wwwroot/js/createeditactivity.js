//Data to autofill the address when a location is chosen from htmlSelect
const streetInput = document.querySelector("#streetInput");
const numberInput = document.querySelector("#numberInput");
const unitInput = document.querySelector("#unitInput");
const postalCodeInput = document.querySelector("#postalCodeInput");
const cityInput = document.querySelector("#cityInput");
const locationSelect = document.querySelector("#locationSelect");

const locationData = JSON.parse(locationSelect.dataset.locations);


//Data to toggle button to add a new location
const addLocationButton = document.querySelector("#addLocationButton");
const knownLocation = document.querySelector("#knownLocation");
const newLocation = document.querySelector("#newLocation");
const saveLocationFormCheck = document.querySelector("#saveLocationForm-Check");


//Logic to fill address when location is selected
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



//logic to toggle between input and select when button to add location is toggled
addLocationButton.addEventListener("click", function () {

    newLocation.classList.toggle("invisible");
    knownLocation.classList.toggle("invisible");
    saveLocationFormCheck.classList.toggle("invisible")


    const isAdding = addLocationButton.textContent.trim() === "Locatie toevoegen";
    addLocationButton.textContent = isAdding ? "Opgeslagen locatie" : "Locatie toevoegen";
})