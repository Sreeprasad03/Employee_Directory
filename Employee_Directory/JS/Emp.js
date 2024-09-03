$(document).ready(function () {
    Fill_Passing_Type('location', '');
    Fill_Dep_Type('department', '');
    FetchEmpDetails();
    $('#employeeModal .close').on('click', function () {
        $('#employeeModal').hide();
    });
    $('#location').change(function () {
        Fetch_EmpDetails();
    });
});
function FetchEmpDetails() {
    var Emp_ID = "0";
    let data = {
        Emp_ID: Emp_ID
    };

    $.ajax({
        cache: false,
        type: "POST",
        url: "/Emp/EmpDetails",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (response) {
            var empDetails = response;

            $('#EmpDetails').empty();
            if (Array.isArray(empDetails)) {
                $.each(empDetails, function (index, emp) {
                    var imageUrl = emp.Emp_ImageURL;

                    $('#EmpDetails').append(
                        '<div class="emp-detail" data-emp-id="' + emp.Emp_ID + '">' +
                        '<img src="' + imageUrl + '" alt="Profile Picture" class="profile-pic">' +
                        '<h4>' + emp.Emp_Name + '</h4>' +
                        '<p>' + emp.Emp_Desg + '</p>' +
                        '<p>' + emp.Emp_Dep + '</p>' +
                        '<p>' + emp.Emp_ID + '</p>' +
                        '</div>'
                    );
                });

              
                $('.emp-detail').on('click', function () {
                    var empId = $(this).data('emp-id');
                    OpenEmpDetailModal(empId);
                });
            } else {
                $('#EmpDetails').append('<p>Unexpected data format received.</p>');
            }
        },
        complete: function () {
          
        },
        error: function () {
            $('#EmpDetails').append('<p>Error loading employee details. Please try again later.</p>');
        }
    });
}
function OpenEmpDetailModal(empId) {
    let data = {
        Emp_ID: empId
    };
    $.ajax({
        cache: false,
        type: "POST",
        url: "/Emp/EmpDetails",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (response) {
            console.log('Employee Details:', response);
            if (response && response.length > 0) {
                var details = response[0];

                // Update modal content
                $('#employeeModal .modal-content').html(`
                    <div class="modal-header">
                        <h2>${details.Emp_Name || 'Employee Details'}</h2>
                        <span class="close">&times;</span>
                    </div>
                    <div class="modal-body">
                        <div class="employee-image">
                         <img src="${details.Emp_ImageURL}"
                                 alt="Employee Image"
                                 onerror="this.onerror=null; this.src='../../Content/Img/testimonial-2.jpg'; this.alt='Default Image';">
                        </div>
                        <div class="employee-details">
                            <div class="detail-group">
                                <p><strong>ID:</strong> ${details.Emp_ID || 'N/A'}</p>
                                <p><strong>Designation:</strong> ${details.Emp_Desg || 'N/A'}</p>
                                <p><strong>Department:</strong> ${details.Emp_Dep || 'N/A'}</p>
                            </div>
                            <div class="detail-group">
                                <p><strong>Total Experience:</strong> ${details.Emp_totalExp || 'N/A'}</p>
                                <p><strong>In-House Experience:</strong> ${details.Emp_InHouse_Exp || 'N/A'}</p>
                                <p><strong>Team:</strong> ${details.Emp_Team || 'N/A'}</p>
                                <p><strong>Reporting Manager:</strong> ${details.Emp_Rp_Manager || 'N/A'}</p>
                            </div>
                            <div class="detail-group">
                                <p><strong>Days Present:</strong> ${details.Emp_Days_Present || 'N/A'}</p>
                                <p><strong>Casual Leaves:</strong> ${details.Emp_Casucal || 'N/A'}</p>
                                <p><strong>Sick Leaves:</strong> ${details.Emp_Silck || 'N/A'}</p>
                            </div>
                            <div class="detail-group">
                                <p><strong>Status:</strong> ${details.Emp_Status || 'N/A'}</p>
                                <p><strong>Probation:</strong> ${details.Emp_Probation || 'N/A'}</p>
                                <p><strong>Accessible:</strong> ${details.Emp_Acessable || 'N/A'}</p>
                                <p><strong>Payable:</strong> ${details.Emp_Payable || 'N/A'}</p>
                            </div>
                            <div class="detail-group full-width">
                                <p><strong>Address:</strong> ${details.Emp_Address || 'N/A'}</p>
                                <p><strong>Message:</strong> ${details.Emp_Message || 'N/A'}</p>
                            </div>
                        </div>
                    </div>
                `);

                // Show the modal
                $('#employeeModal').show();

                // Close modal when clicking on the close button
                $('.close').on('click', function () {
                    $('#employeeModal').hide();
                });
            } else {
                alert('No details found for this employee.');
            }
        },
        error: function (xhr, status, error) {
            console.error('AJAX Error:', status, error);
            alert('Error loading employee details. Please try again later.');
        }
    });
}



  

function Fill_Passing_Type(CmbBx) {

    let DefaultType = '';



    let data =
    {

        DefaultType: DefaultType
    }
    $.ajax({
        cache: false,
        type: "POST",
        url: "/Emp/EmpLocation",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,

        success: function (data) {
            
            $(`#${CmbBx}`).empty();
            var defaultOption = new Option("Select", "");
            $(`#${CmbBx}`).append(defaultOption);
            for (var i in data) {
                var Opt = new Option(data[i].Name, data[i].ID);
                $(`#${CmbBx}`).append(Opt);
            }

        },
        complete: function (data) {
            $("#overlay").hide();
        },
        error: function (data, success, error) {
            alert(error);
        }
    });
    }

function Fill_Dep_Type(CmbBx) {

    let DefaultType = '';



    let data =
    {

        DefaultType: DefaultType
    }
    $.ajax({
        cache: false,
        type: "POST",
        url: "/Emp/EmpDep",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,

        success: function (data) {
            $(`#${CmbBx}`).empty();
            for (var i in data) {
                var Opt = new Option(data[i].Name, data[i].ID);
                $(`#${CmbBx}`).append(Opt);
            }

        },
        complete: function (data) {
            $("#overlay").hide();
        },
        error: function (data, success, error) {
            alert(error);
        }
    });
}

function Fetch_EmpDetails() {
   
    let Location = $("#location option:selected").text();

    let data = {
        Location: Location
    };

    $.ajax({
        cache: false,
        type: "POST",
        url: "/Emp/Emp_Details",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (response) {
            var empDetails = response;

            $('#EmpDetails').empty();
            if (Array.isArray(empDetails)) {
                $.each(empDetails, function (index, emp) {
                    var imageUrl = emp.Emp_ImageURL;

                    $('#EmpDetails').append(
                        '<div class="emp-detail" data-emp-id="' + emp.Emp_ID + '">' +
                        '<img src="' + imageUrl + '" alt="Profile Picture" class="profile-pic">' +
                        '<h4>' + emp.Emp_Name + '</h4>' +
                        '<p>' + emp.Emp_Desg + '</p>' +
                        '<p>' + emp.Emp_Dep + '</p>' +
                        '<p>' + emp.Emp_ID + '</p>' +
                        '</div>'
                    );
                });


                $('.emp-detail').on('click', function () {
                    var empId = $(this).data('emp-id');
                    OpenEmpDetailModal(empId);
                });
            } else {
                $('#EmpDetails').append('<p>Unexpected data format received.</p>');
            }
        },
        complete: function () {

        },
        error: function () {
            $('#EmpDetails').append('<p>Error loading employee details. Please try again later.</p>');
        }
    });
}