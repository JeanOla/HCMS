// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.sidebar .nav-link').forEach(function (element) {

        element.addEventListener('click', function (e) {

            let nextEl = element.nextElementSibling;
            let parentEl = element.parentElement;

            if (nextEl) {
                e.preventDefault();
                let mycollapse = new bootstrap.Collapse(nextEl);

                if (nextEl.classList.contains('show')) {
                    mycollapse.hide();
                } else {
                    mycollapse.show();
                    // find other submenus with class=show
                    var opened_submenu = parentEl.parentElement.querySelector('.submenu.show');
                    // if it exists, then close all of them
                    if (opened_submenu) {
                        new bootstrap.Collapse(opened_submenu);
                    }
                }
            }
        }); // addEventListener
    }) // forEach
});
$(document).ready(function () {
    $('#myModal').modal('show');
});

$(document).ready(function () {
    $('#doctorList').DataTable();
});

//change the option for appointment
$(document).ready(function () {
    $('#appointmentDay').on('change', function () {
        var selectedValue = $(this).val();
        $.ajax({
            url: '/Appointment/changeDay',
            type: 'POST',
            data: { newDay: selectedValue },
            success: function (data) {
                var doctorIdDropdown = $('#doctor');
                doctorIdDropdown.empty();
                $.each(data, function ( option) {
                    doctorIdDropdown.append($('<option>', {
                        Value: option.Value,
                        Text: option.Text
                    }));
                });
            },
            error: function (xhr, status, error) {
                alert("asda");
            }
        });
    });
});