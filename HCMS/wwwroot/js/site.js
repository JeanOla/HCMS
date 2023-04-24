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
$(document).ready(function () {
    $('#doctorScheduleList').DataTable();
});

//end
//appointment JS code
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})
//real  change the option for appointment for UPDATE AND CREATE
function changeDoctor() {
    $.ajax({
        url: '/Appointment/changeDay',
        type: 'POST',
        data: { newDay: $('#appointmentDay').val() },
        success: function (data) {
            var doctorIdDropdown = $('#doctor');
            var selectedDoctorId = doctorIdDropdown.val(); // get the currently selected doctor id
            doctorIdDropdown.empty();
            $.each(data, function (index, option) {
                var optionElement = $('<option>', {
                    value: option.value,
                    text: option.text
                });
                if (option.value == selectedDoctorId) { // if this option has the same value as the selected doctor id, mark it as selected
                    optionElement.prop('selected', true);
                }
                doctorIdDropdown.append(optionElement);
            });
        },
        error: function (xhr, status, error) {
            alert("error");
        }
    });
}
function setdate(){
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    var dateString = yyyy + '-' + mm + '-' + dd;
    $("#appointmentDay").val(dateString);

    var today = new Date();
    $('#appointmentDay').datepicker({
        defaultDate: today
    });
}

$(document).ready(function () {
    
    changeDoctor();
   
    $('#appointmentDay').on('change', function () {
        $.ajax({
            url: '/Appointment/changeDay',
            type: 'POST',
            data: { newDay: $(this).val() },
            success: function (data) {
                var doctorIdDropdown = $('#doctor');
                doctorIdDropdown.empty();
                doctorIdDropdown.append($('<option>', {
                    value: '',
                    text: 'Select a doctor'
                }));
                $.each(data, function (index, option) {
                    doctorIdDropdown.append($('<option>', {
                        value: option.value,
                        text: option.text
                    }));
                });
            },
            error: function (xhr, status, error) {
                alert("error");
            }
        });
    });

    $('.spin').click(function(e) {
      e.preventDefault();
      $('#spinner-modal').modal('show');
      var url = $(this).attr('href');
      setTimeout(function() { 
        window.location.href = url; 
      }, 1000);
    });
});

$('#form-spinner').submit(function (e) {
    // prevent the default form submission
    e.preventDefault();

    // show the spinner modal
    $('#spinner-modal').modal('show');

    // wait 1 second and then submit the form
    setTimeout(function () {
        $('#form-spinner').off('submit').submit();
    }, 1000);
});

$('#login-form').submit(function (e) {
    // prevent the default form submission
    e.preventDefault();

    // show the spinner modal
    $('#spinner-modal').modal('show');

    // wait 1 second and then submit the form
    setTimeout(function () {
        $('#login-form').off('submit').submit();
    }, 1000);
});

$('#myForm').submit(function (e) {
    // prevent the default form submission
    e.preventDefault();

    // show the spinner modal
    $('#spinner-modal').modal('show');

    // wait 1 second and then submit the form
    setTimeout(function () {
        $('myForm').off('submit').submit();
    }, 1000);
});



/*appointment creation - change the value of check schedule list whenever the user change the value of doctorId dropdownlist*/
$(document).ready(function () {
    $('#doctor').change(function () {
        var selectedValue = $(this).val();
        $('#Id').val(selectedValue);
    });
});
$(document).ready(function () {
    var selectedValue = $('#doctor').val();
    $('#Id').val(selectedValue);


    $('#doctor').change(function () {
        var selectedValue = $(this).val();
        $('#Id').val(selectedValue);
    });
});