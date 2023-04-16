// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// sidebar menu.
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

//appointment JS code
//start
//change the option for appointment for UPDATE AND CREATE
//$(document).ready(function () { // working
//    $('#appointmentDay').on('change', function () {
//        var selectedValue = $(this).val();
//        $.ajax({
//            url: '/Appointment/changeDay',
//            type: 'POST',
//            data: { newDay: selectedValue },
//            success: function (data) {
//                var doctorIdDropdown = $('#doctor');
//                doctorIdDropdown.empty();
//                $.each(data, function (index, option) {
//                    doctorIdDropdown.append($('<option>', {
//                        value: option.value,
//                        text: option.text
//                    }));
//                });
//            },
//            error: function (xhr, status, error) {
//                alert("asda");
//            }
//        });
//    });
//});

//$(document).ready(function () { //working
//    $('#appointmentDay').on('onload', function () {
//        var selectedValue = $(this).val();
//        $.ajax({
//            url: '/Appointment/changeDay',
//            type: 'POST',
//            data: { newDay: selectedValue },
//            success: function (data) {
//                var doctorIdDropdown = $('#doctor');
//                doctorIdDropdown.empty();
//                $.each(data, function (index, option) {
//                    doctorIdDropdown.append($('<option>', {
//                        value: option.value,
//                        text: option.text
//                    }));
//                });
//            },
//            error: function (xhr, status, error) {
//                alert("asda");
//            }
//        });
//    });
//});

//$(document).ready(function () {
    
//        var selectedValue = $(this).val();
//        $.ajax({
//            url: '/Appointment/changeDay',
//            type: 'POST',
//            data: { newDay: selectedValue },
//            success: function (data) {
//                var doctorIdDropdown = $('#doctor');
//                doctorIdDropdown.empty();
//                $.each(data, function (index, option) {
//                    doctorIdDropdown.append($('<option>', {
//                        value: option.value,
//                        text: option.text
//                    }));
//                });
//            },
//            error: function (xhr, status, error) {
//                alert("asda");
//            }
//        });
  
//});


//end
//appointment JS code
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})
//real  change the option for appointment for UPDATE AND CREATE
$(document).ready(function () {
    $('#appointmentDay').on('change', function () {
        $.ajax({
            url: '/Appointment/changeDay',
            type: 'POST',
            data: { newDay: $(this).val() },
            success: function (data) {
                var doctorIdDropdown = $('#doctor');
                doctorIdDropdown.empty();
                $.each(data, function (index, option) {
                    doctorIdDropdown.append($('<option>', {
                        value: option.value,
                        text: option.text
                    }));
                });
            },
            error: function (xhr, status, error) {
                alert("asda");
            }
        });
    });
});

