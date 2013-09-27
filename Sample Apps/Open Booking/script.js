function popupCalendar(id) {
    var dateField = document.getElementById(id);

    // toggle the div
    if (dateField.style.display == 'none')
        dateField.style.display = 'block';
    else
        dateField.style.display = 'none';
}