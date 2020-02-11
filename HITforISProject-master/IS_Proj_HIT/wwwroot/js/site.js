// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    console.log('Hi');


    $.validator.addMethod("alphabetsnspace", function (value, element) {
        return this.optional(element) || /^[a-zA-Z ]*$/.test(value);
    });

    // Check for DOB of less that today's date
    $.validator.addMethod("maxDate", function (value, element) {
        var curDate = new Date();
        var inputDate = new Date(value);
        if (inputDate < curDate)
            return true;
        return false;
    }, "Invalid Date from the future!");   // error message

    // Check for DOB of 100 years before this year
    $.validator.addMethod("minDate", function (value, element) {
        var testYear = (new Date).getFullYear();
        var testDate = new Date((testYear - 100), 1, 1);
        var inputDate = new Date(value);
        if (inputDate > testDate)
            return true;
        return false;
    }, "Too far in the past!");   // error message

    $.validator.addMethod("valueNotEquals", function (value, element, arg) {
        return arg !== value;
    }, "Value must not equal arg.");

    $.validator.setDefaults({ ignore: ":hidden:not(select)" })
    //$.validator.setDefaults({ ignore: ":hidden:not(.chosen-select)" })

    $("form[name='patient']").validate({
        // Specify validation rules
        rules: {
            FirstName: {
                required: true,
                alphabetsnspace: true
            },
            MiddleName: "alphabetsnspace",
            lastName: {
                required: true,
                alphabetsnspace: true
            },
            aliasFirstName: "alphabetsnspace",
            aliasMiddleName: "alphabetsnspace",
            aliasLastName: "alphabetsnspace",
            MaidenName: "alphabetsnspace",
            MothersMaidenName: "alphabetsnspace",
            MaritalStatusId: "required",
            SexId: "required",
            EthnicityId: "required",

            Dob: {
                required: true,
                date: true,
                maxDate: true,
                minDate: true
            },
            Ssn: {
                required: true,
                minlength: 9
            }
           

        },
        // Specify validation error messages
        messages: {
            
            FirstName: {
                required: "Please provide a first name",
                alphabetsnspace: "First name must be all letters"
            },
            lastName: {
                required: "Please provide a last name",
                alphabetsnspace: "Last name must be all letters"
            },
            Ssn: {
                required: "Please provide a Social Security Number",
                minlength: "Your SSN must be at least 10 digits long"
            },

            Dob: {
                required: "Please provide a valid date of birth",
                date: "Please provide a valid date of birth",
                maxDate: "Invalid Date from the future!",
                minDate: "Too far in the past!"
            },
            MiddleName: "Only one letter allowed",
            aliasFirstName: "Only letters allowed",
            aliasMiddleName: "Only letters allowed",
            aliasLastName: "Only letters allowed",
            MothersMaidenName: "Only letters allowed",
            MaidenName: "Only letters allowed",
            MaritalStatusId: "Select a Marital Status from the list",
            EthnicityId: "Select an Ethnicity from the list",
            SexId: "Select a Sex from the list"
            
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });

    $("form[name='patientEdit']").validate({
        // Specify validation rules
        rules: {
            FirstName: {
                required: true,
                alphabetsnspace: true
            },
            MiddleName: "alphabetsnspace",
            lastName: {
                required: true,
                alphabetsnspace: true
            },
            aliasFirstName: "alphabetsnspace",
            aliasMiddleName: "alphabetsnspace",
            aliasLastName: "alphabetsnspace",
            MaidenName: "alphabetsnspace",
            MothersMaidenName: "alphabetsnspace",
            Dob: {
                required: true,
                date: true,
                maxDate: true,
                minDate: true
            },
            Ssn: {
                required: true,
                minlength: 9
            },
            MaritalStatusId: "required",
            SexId: "required",
            EthnicityId: "required",
            

        },
        // Specify validation error messages
        messages: {
            FirstName: {
                required: "Please provide a first name",
                alphabetsnspace: "First name must be all letters"
            },
            lastName: {
                required: "Please provide a last name",
                alphabetsnspace: "Last name must be all letters"
            },
            Ssn: {
                required: "Please provide a Social Security Number",
                minlength: "Your SSN must be at least 10 digits long"
            },
            MiddleName: "Only one letter allowed",
            aliasFirstName: "Only letters allowed",
            aliasMiddleName: "Only letters allowed",
            aliasLastName: "Only letters allowed",
            MothersMaidenName: "Only letters allowed",
            MaidenName: "Only letters allowed",
            MaritalStatusId: "Select a Marital Status from the list",
            EthnicityId: "Select an Ethnicity from the list",
            SexId: "Select a Sex from the list",
            Dob: {
                required: "Please provide a valid date of birth",
                date: "Please provide a valid date of birth",
                maxDate: "Please provide a valid date of birth",
                minDate: "Please provide a valid date of birth"
            }
            
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });

    var admitDateTime;
    $(document).ready(function () {
        admitDateTime = $("#admitDateTime").val();
    });
    $("#editEncounter").on("submit", function () {
        console.log(admitDateTime);
        if ($("#admitDateTime").val() == '') {
            $("#admitDateTime").val(admitDateTime);
            console.log($("#admitDateTime").val());
        }
    });

    $("form[name='encounter']").validate({
        // Specify validation rules
        rules: {
            RoomNumber: "required",
            ChiefComplaint: "required",
            FacilityId: "required",
            DepartmentId: "required",
            PointOfOriginId: "required",
            PlaceOfServiceId: "required",
            AdmitTypeId: "required",
            EncounterPhysiciansId: "required",
            EncounterTypeId: "required"
        },
        // Specify validation error messages
        messages: {
            RoomNumber: "Please enter the room number the patient is in for their encounter",
            ChiefComplaint: "Please enter the patients reason for coming to the hospitial",
            FacilityId: "Select a Facility from the list",
            DepartmentId: "Select a Department from the list",
            PointOfOriginId: "Select a Point of Origin from the list",
            PlaceOfServiceId: "Select a Place of Service from the list",
            AdmitTypeId: "Select an Admission Types from the list",
            EncounterPhysiciansId: "Select a Physician from the list",
            EncounterTypeId: "Select an Encounter Type from the list"

        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });

    $("form[name='editEncounter']").validate({
        // Specify validation rules
        rules: {
            RoomNumber: "required",
            ChiefComplaint: "required",
            FacilityId: "required",
            DepartmentId: "required",
            PointOfOriginId: "required",
            PlaceOfServiceId: "required",
            AdmitTypeId: "required",
            EncounterPhysiciansId: "required",
            EncounterTypeId: "required"
        },
        // Specify validation error messages
        messages: {
            RoomNumber: "Please enter the room number the patient is in for their encounter",
            ChiefComplaint: "Please enter the patients reason for coming to the hospitial",
            FacilityId: "Select a Facility from the list",
            DepartmentId: "Select a Department from the list",
            PointOfOriginId: "Select a Point of Origin from the list",
            PlaceOfServiceId: "Select a Place of Service from the list",
            AdmitTypeId: "Select an Admission Types from the list",
            EncounterPhysiciansId: "Select a Physician from the list",
            EncounterTypeId: "Select an Encounter Type from the list"

        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });

    // Calc age from DOB input in add/edit patient when leaving DOB field HELPMEIMDYING
    $('.dob').focusout(function () {
        var dob = $('.dob').val();
        console.log("Hello " + dob);
        console.log('Hi you left the field, ' + dob);

        if (dob != '') {
            var DateCreated = new Date(Date.parse(dob));
            var today = new Date();

            var dayDiff = Math.ceil(today - DateCreated) / (1000 * 60 * 60 * 24 * 365);
            console.log("dayDiff " + dayDiff);
            var age = parseInt(dayDiff);
            console.log("calcified age " + age);
            $('.age').text(age);

            // Format DOB in patient banner
            var str = $('.dob').val();
            var year = str.substring(0, 4);
            var month = str.substring(5, 7);
            var day = str.substring(8, 10);
            $('#calcDOB').text(month + '/' + day + '/' + year);

        }
    });

    // Update first, middle and last names in patient banner with those fields are edited in the Edit Page
    $('#FirstName').focusout(function () {
        var firstname = $('#FirstName').val();
        var middlename = $('#MiddleName').val();
        var lastname = $('#LastName').val();
        $('#fullName').text(firstname + " " + middlename + " " + lastname);
    });
    $('#MiddleName').focusout(function () {
        var firstname = $('#FirstName').val();
        var middlename = $('#MiddleName').val();
        var lastname = $('#LastName').val();
        $('#fullName').text(firstname + " " + middlename + " " + lastname);
    });
    $('#LastName').focusout(function () {
        var firstname = $('#FirstName').val();
        var middlename = $('#MiddleName').val();
        var lastname = $('#LastName').val();
        $('#fullName').text(firstname + " " + middlename + " " + lastname);
    });

    // When Edit page loads
    $(function () {
        // DOB in Edit page patient banner
        var dob = $('.dob').val();
        if (dob != '') {
            var DateCreated = new Date(Date.parse(dob));
            var today = new Date();

            var dayDiff = Math.ceil(today - DateCreated) / (1000 * 60 * 60 * 24 * 365);

            var age = parseInt(dayDiff);

            $('.age').text(age);
            

        }
        // MRN in Edit page patient banner
        var mrn = $('.mrn').val();
        $('#calcMRN').text(mrn);

        // First, middle and last name
        var firstname = $('#FirstName').val();
        var middlename = $('#MiddleName').val();
        var lastname = $('#LastName').val();
        $('#fullName').append(firstname + '&nbsp;' + middlename + '&nbsp;' + lastname);

        // Format DOB in patient banner
        var str = $('.dob').val();
        var year = str.substring(0, 4);
        var month = str.substring(5, 7);
        var day = str.substring(8, 10);
        $('#calcDOB').text(month + '/' + day + '/' + year);


    });

    // Calc age in div in Details page
    $(function () {
        var dob = $('.dob').html();

        if (dob != '') {
            var DateCreated = new Date(Date.parse(dob));
            var today = new Date();

            var dayDiff = Math.ceil(today - DateCreated) / (1000 * 60 * 60 * 24 * 365);

            var age = parseInt(dayDiff);

            $('.age').text(age);
            $('.age').css('background-color', 'gold');

        }
    });

    // When SSN is being edited, the dashes are added
    $('#Ssn').keyup(function () {
        var val = this.value.replace(/\D/g, '');
        val = val.replace(/^(\d{3})/, '$1-');
        val = val.replace(/-(\d{2})/, '-$1-');
        val = val.replace(/(\d)-(\d{4}).*/, '$1-$2');
        this.value = val;
    });

    // When page loads, if SSN field is on there, this adds the dashes
    $(function () {
        var val = $('#Ssn').text();
        val.replace(/\D/g, '');
        val = val.replace(/^(\d{3})/, '$1-');
        val = val.replace(/-(\d{2})/, '-$1-');
        val = val.replace(/(\d)-(\d{4}).*/, '$1-$2');
        $('#Ssn').html(val);
    });

    // When user clicks save or create on Add Patient or Edit Patient page
    $('#formatSsnAndSubmitForm').on('click', function () {
        var temp = $('#Ssn').val();
        var fixed = temp.replace(/-/g, '')
        $('#Ssn').val(fixed);
    });


    $('#formatSsnAndSubmitForm').hide();

    $("#patientEdit").on('change', function () {
        $('#formatSsnAndSubmitForm').show();
    });

    $('#patient').on('change', function () {
        $('#formatSsnAndSubmitForm').show();
    });


    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#allergylist").filter(function () {
            $(this).toggle($(this).asp-items().toLowerCase().indexOf(value) > -1)
        });
    });

    $('.chosen').chosen({ width: '50%' });

    $('[data-toggle="tooltip"]').tooltip();

});
    


