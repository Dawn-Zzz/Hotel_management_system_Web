'use strict';

const guestTable = document.querySelector('.guest-table');
const staffTable = document.querySelector('.staff-table');
const addRoomBtn = document.querySelector('#add-room-btn');
const addServiceBtn = document.querySelector('#add-service-btn');
const addRoomForm = document.querySelector('.add-room-form');
const addServiceForm = document.querySelector('.add-service-form');
const submitBtn = document.querySelector('.submit-form-btn');
const submitRoom = document.querySelector('.submit-room');
const submitService = document.querySelector('.submit-service');
const closeEvents = document.querySelectorAll('.close-btn, .room-form');
const roomContainer = document.querySelector('.room-container');
const serviceContainer = document.querySelector('.service-container');
const roomChosen = document.querySelector('.room-chosen');
const serviceChosen = document.querySelector('.service-chosen');

const registrationPhoneNumber = document.getElementById("phone-number");
var registraionDateCheckIn = document.getElementById("checkIn");
var registraionDateCheckOut = document.getElementById("checkOut");

console.log(addRoomBtn);

if (guestTable) {
    const guestApp = {
        guests: [
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
            {
                name: 'Nguyen Van A',
                room: 'Room name',
                phoneNumber: '0987654321',
                age: 40,
                checkIn: '01/01/2023',
                checkOut: '02/01/2023',
            },
        ],
        guestRender: function () {
            const guestslist = this.guests.map((guest, index) => {
                return `
                    <tr>
                        <td>${index + 1}</td>
                        <td>${guest.name}</td>
                        <td>${guest.room}</td>
                        <td>${guest.phoneNumber}</td>
                        <td>${guest.age}</td>
                        <td>${guest.checkIn}</td>
                        <td>${guest.checkOut}</td>
                    </tr>
                `
            })
            guestTable.innerHTML = guestslist.join("");
        },

        start: function () {
            this.guestRender();
        }
    }
    guestApp.start();
}

if (staffTable) {
    const staffApp = {
        staffs: [
            {
                name: 'Nguyen Van B',
                indentification: '123456789012',
                phoneNumber: '0987654321',
                birthday: '01/01/2023',
                role: 'Staff'
            },
            {
                name: 'Nguyen Van B',
                indentification: '123456789012',
                phoneNumber: '0987654321',
                birthday: '01/01/2023',
                role: 'Staff'
            },
            {
                name: 'Nguyen Van B',
                indentification: '123456789012',
                phoneNumber: '0987654321',
                birthday: '01/01/2023',
                role: 'Staff'
            },
            {
                name: 'Nguyen Van B',
                indentification: '123456789012',
                phoneNumber: '0987654321',
                birthday: '01/01/2023',
                role: 'Staff'
            },
            {
                name: 'Nguyen Van B',
                indentification: '123456789012',
                phoneNumber: '0987654321',
                birthday: '01/01/2023',
                role: 'Staff'
            },
            {
                name: 'Nguyen Van B',
                indentification: '123456789012',
                phoneNumber: '0987654321',
                birthday: '01/01/2023',
                role: 'Staff'
            },
            {
                name: 'Nguyen Van B',
                indentification: '123456789012',
                phoneNumber: '0987654321',
                birthday: '01/01/2023',
                role: 'Staff'
            },
            {
                name: 'Nguyen Van B',
                indentification: '123456789012',
                phoneNumber: '0987654321',
                birthday: '01/01/2023',
                role: 'Staff'
            },
        ],
        staffRender: function () {
            const staffslist = this.staffs.map((staff, index) => {
                return `
                    <tr>
                        <td>${index + 1}</td>
                        <td>${staff.name}</td>
                        <td>${staff.indentification}</td>
                        <td>${staff.phoneNumber}</td>
                        <td>${staff.birthday}</td>
                        <td>${staff.role}</td>
                    </tr>
                `
            })
            staffTable.innerHTML = staffslist.join("");
        },

        start: function () {
            this.staffRender();
        }
    }
    staffApp.start();
}

const familyRoomList = document.querySelector('.family-room-list');
if (familyRoomList) {
    //const roomApp = {
    //    rooms: [
    //        {
    //            roomStatus: 1,
    //        },
    //        {
    //            roomStatus: 2,
    //        },
    //        {
    //            roomStatus: 3,
    //        },
    //        {
    //            roomStatus: 4,
    //        },
    //        {
    //            roomStatus: 1,
    //        },
    //        {
    //            roomStatus: 2,
    //        },
    //        {
    //            roomStatus: 3,
    //        },
    //        {
    //            roomStatus: 4,
    //        },
    //        {
    //            roomStatus: 1,
    //        },
    //        {
    //            roomStatus: 2,
    //        },
    //        {
    //            roomStatus: 3,
    //        },
    //        {
    //            roomStatus: 4,
    //        },
    //        {
    //            roomStatus: 1,
    //        },
    //        {
    //            roomStatus: 2,
    //        },
    //        {
    //            roomStatus: 3,
    //        },
    //        {
    //            roomStatus: 4,
    //        },
    //    ],

    //    roomRender: function () {
    //        const roomslist = this.rooms.map((room, index) => {
    //            var status = "";
    //            var icon = "";
    //            var statusName = "";
    //            if (room.roomStatus == 1) {
    //                status = "primary";
    //                icon = "minus";
    //                statusName = "OCCUPIED ROOM";
    //            } else if (room.roomStatus == 2) {
    //                status = "success";
    //                icon = "check";
    //                statusName = "AVAILABLE ROOM";
    //            } else if (room.roomStatus == 3) {
    //                status = "danger";
    //                icon = "xmark";
    //                statusName = "ROOM OFF";
    //            } else {
    //                status = "warning";
    //                icon = "exclamation";
    //                statusName = "BOOK IN ADVANCE";
    //            }
    //            return `
    //                    <div class="card border-left-${status} shadow h-100 py-2">
    //                        <div class="room-body">
    //                            <div class="row no-gutters align-items-center">
    //                                <div class="col mr-2">
    //                                    <div class="text-xs font-weight-bold text-${status} text-uppercase mb-1">
    //                                        ${statusName}
    //                                    </div>
    //                                    <div class="h5 mb-0 font-weight-bold text-gray-800">P1${String(index).padStart(2, '0')} </div>
    //                                </div>
    //                                <div class="col-auto">
    //                                    <i class="fa-solid fa-circle-${icon} fa-2x text-gray-300"></i>
    //                                </div>
    //                            </div>
    //                        </div>
    //                    </div>
    //            `
    //        })
    //        familyRoomList.innerHTML = roomslist.join("");
    //    },

    //    start: function () {
    //        this.roomRender();
    //    }
    //}
    //roomApp.start();
    var status = "";
    var icon = "";
    var statusName = "";
    if (room.roomStatus == 1) {
        status = "primary";
        icon = "minus";
        statusName = "OCCUPIED ROOM";
    } else if (room.roomStatus == 2) {
        status = "success";
        icon = "check";
        statusName = "AVAILABLE ROOM";
    } else if (room.roomStatus == 3) {
        status = "danger";
        icon = "xmark";
        statusName = "ROOM OFF";
    }
    const roomBox = `
        <div class="col-xl-3 col-md-6 mb-4 ">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="room-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-${status} text-uppercase mb-1">
                                @Html.DisplayFor(modelItem => item.HienTrang)
                            </div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">@Html.DisplayFor(modelItem => item.MaPhong)</div>
                        </div>
                        <div class="col-auto">
                            <i class="fa-solid fa-circle-${icon} fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    `
}

function hideForm() {
    if (addRoomForm)
        addRoomForm.style.display = "none";
    if (addServiceForm)
        addServiceForm.style.display = "none";
}

if (addRoomForm) {
    const roomInfor = [];
    if (!registrationPhoneNumber.value || !registraionDateCheckIn.value) {
        addRoomBtn.style.opacity = "0.3";
        addRoomBtn.style.cursor = "default";
    }
    registrationPhoneNumber.onchange = () => {
        if (registrationPhoneNumber.value != "" && registraionDateCheckIn.value != "") {
            addRoomBtn.style.opacity = "1";
            addRoomBtn.style.cursor = "pointer";
        }
        else if (registrationPhoneNumber.value == "") {
            addRoomBtn.style.opacity = "0.3";
            addRoomBtn.style.cursor = "default";
        }
    }
    addRoomBtn.onclick = (e) => {
        if (!registrationPhoneNumber.value || !registraionDateCheckIn.value) {
            e.preventDefault();
            console.log("Please enter phone number and check-in date before adding room.");
        }
        else {
            console.log(addRoomForm);
            addRoomForm.style.display = "flex";
            //const roomNode = e.target.closest('.room');
            //if (roomNode) {

            //const typeOfRoom = roomNode.querySelector('.room-type');
            //const imgPath = roomNode.querySelector('.img-fluid');

            const roomID = addRoomForm.querySelector('.room-id')
            const roomNumber = addRoomForm.querySelector('.room-number');
            const clienQuantity = addRoomForm.querySelector('.clien-quantity');

            roomID.value = null;
            roomNumber.value = null;
            clienQuantity.value = 0;

            //formImage.style.background = `url('${imgPath.src.slice(23)}') top center / cover no-repeat`;
            var blockIndexes = [];
            submitRoom.onclick = () => {
                while (roomInfor.length > 0) {
                    roomInfor.pop();
                }
                roomInfor.push(
                    roomID.value,
                    roomNumber.value,
                    clienQuantity.value
                );
                var isNull = roomInfor.every((clientValue, index) => {
                    return clientValue != "";
                });
                if (isNull) {
                    $.ajax({
                        url: 'AddBookRoom',
                        type: 'POST',
                        data: {
                            maPhong: roomNumber.value,
                            soNguoiO: clienQuantity.value
                        },
                    });
                    var newBlock = document.createElement('tr');

                    var roomIDValue = document.createElement('td');
                    var roomNumberValue = document.createElement('td');
                    var clientQuantityValue = document.createElement('td');

                    roomIDValue.innerHTML = roomID.value.trim();
                    roomNumberValue.innerHTML = roomNumber.value.trim();
                    clientQuantityValue.innerHTML = clienQuantity.value.trim();

                    newBlock.className = 'roomBlock';
                    var deleteBtn = document.createElement('td');
                    deleteBtn.className = 'delete-btn';
                    deleteBtn.innerHTML = 'Delete';

                    var roomBlockQuantity = document.querySelectorAll(".roomBlock");
                    console.log(roomBlockQuantity);

                    deleteBtn.onclick = () => {
                        var i = blockIndexes.indexOf(newBlockIndex);
                        if (i !== -1) {
                            blockIndexes.splice(i, 1);
                        }
                        roomChosen.removeChild(newBlock);
                        $.ajax({
                            url: 'GetMaPhongByIndex',
                            type: 'GET',
                            data: { index: i },
                            success: function (MaPhong) {
                                if (MaPhong) {
                                    $.ajax({
                                        url: 'DeleteBookRoom',
                                        type: 'POST',
                                        data: { maPhong: MaPhong.maPhong },
                                        success: function (response) {
                                            if (response.success) {
                                                console.log('Phòng đã được xóa thành công.');
                                            } else {
                                                console.log('Không thể xóa phòng.');
                                            }
                                        },
                                        error: function () {
                                            console.log('Lỗi khi gửi yêu cầu xóa phòng.');
                                        }
                                    });
                                }
                                else {
                                    console.log('Mã phòng không hợp lệ.');
                                }
                            },
                            error: function () {
                                console.log('Lỗi khi gửi yêu cầu lấy mã phòng.');
                            }
                        });
                        console.log(roomBlockQuantity);
                        if (roomBlockQuantity.length <= 1) {
                            registraionDateCheckIn.style.opacity = "1";
                            registraionDateCheckOut.style.opacity = "1";
                        }
                        registraionDateCheckIn.onclick = (e) => {
                            if (roomBlockQuantity.length <= 1) {
                                registraionDateCheckIn.style.opacity = "1";
                                registraionDateCheckOut.style.opacity = "1";
                                e.preventDefault = false;
                            }
                            else {
                                registraionDateCheckIn.style.opacity = "0.3";
                                registraionDateCheckOut.style.opacity = "0.3";
                            }
                        }
                    }

                    var newBlockIndex = blockIndexes.length;
                    blockIndexes.push(newBlockIndex);

                    newBlock.appendChild(roomIDValue);
                    newBlock.appendChild(roomNumberValue);
                    newBlock.appendChild(clientQuantityValue);
                    newBlock.appendChild(deleteBtn);

                    hideForm();

                    roomChosen.appendChild(newBlock);
                }
                if (roomBlockQuantity.length > 0) {
                    registraionDateCheckIn.style.opacity = "0.3";
                    registraionDateCheckOut.style.opacity = "0.3";
                }
                registraionDateCheckIn.onclick = (e) => {
                    if (roomBlockQuantity.length > 0) {
                        registraionDateCheckIn.style.opacity = "0.3";
                        registraionDateCheckOut.style.opacity = "0.3";
                        e.preventDefault(); 
                    }
                    else {
                        registraionDateCheckIn.style.opacity = "1";
                        registraionDateCheckOut.style.opacity = "1";
                    }
                }
            }

            //formTitle.textContent = typeOfRoom.textContent;
            closeEvents.forEach(closeEvent => {
                closeEvent.addEventListener('click', () => {
                    roomInfor.push(
                        roomID.value,
                        roomNumber.value,
                        clienQuantity.value
                    );
                    //while (clientInfo.length > 0) {
                    //    clientInfo.pop();
                    //}
                    hideForm();
                    //const formGroups = bookingForm.querySelectorAll(".form-group");
                    //const formMessages = bookingForm.querySelectorAll(".form-message");

                    //if (formGroups.length > 0) {
                    //    formGroups.forEach(formGroup => {
                    //        formGroup.classList.remove('invalid');
                    //    })
                    //    formMessages.forEach(formMessage => {
                    //        formMessage.innerText = "";
                    //    })
                    //}
                })
            })
            roomContainer.addEventListener('click', (e) => {
                e.stopPropagation();
            });
        }
        //}
    }
}
function addServiceBlock(serviceInfo) {
    const newBlock = document.createElement('tr');
    newBlock.className = 'serviceBlock';

    var serviceNameValue = document.createElement('td');
    var serviceQuantityValue = document.createElement('td');

    serviceNameValue.innerHTML = serviceInfo.value;
    serviceQuantityValue.innerHTML = serviceInfo.count;

    newBlock.setAttribute('data-index', serviceInfo.index);

    const deleteBtn = document.createElement('td');
    deleteBtn.className = 'delete-btn';
    deleteBtn.innerHTML = 'Delete';

    newBlock.appendChild(serviceNameValue);
    newBlock.appendChild(serviceQuantityValue);
    newBlock.appendChild(deleteBtn);

    serviceChosen.appendChild(newBlock);

    deleteBtn.onclick = () => {
        const indexToDelete = parseInt(newBlock.getAttribute('data-index'));

        if (!isNaN(indexToDelete)) {
            serviceChosen.removeChild(newBlock);
            serviceInfor.splice(indexToDelete, 1);

            $.ajax({
                url: '/RegistrationForm/GetMaDichVuByIndex',
                type: 'GET',
                data: { index: indexToDelete },
                success: function (DichVu) {
                    if (DichVu) {
                        $.ajax({
                            url: '/RegistrationForm/DeleteService',
                            type: 'POST',
                            data: { maDichVu: DichVu.maDichVu },
                            success: function (data) {
                                if (data.success) {
                                    console.log('Dịch vụ đã được xóa thành công.');
                                } else {
                                    console.log('Không thể xóa dịch vụ.');
                                }
                            },
                            error: function () {
                                console.log('Lỗi khi gửi yêu cầu xóa dịch vụ.');
                            }
                        });
                    }
                    else {
                        console.log('Mã dịch vụ không hợp lệ.');
                    }
                },
                error: function () {
                    console.log('Lỗi khi gửi yêu cầu lấy mã dịch vụ.');
                }
            });
        }
    };
}

function resetView(serviceInfor) {
    serviceChosen.innerHTML = `
        <tr>
                    <th class="col-md-5">
                        Service Name
                    </th>
                    <th class="col-md-5">
                        Service Quantity
                    </th>
                    <th class="col-md-2">

                    </th>
                </tr>
    `;

    for (let i = 0; i < serviceInfor.length; i++) {
        const newBlock = document.createElement('tr');
        newBlock.className = 'serviceBlock';

        var serviceNameValue = document.createElement('td');
        var serviceQuantityValue = document.createElement('td');

        serviceNameValue.innerHTML = serviceInfor[i].value;
        serviceQuantityValue.innerHTML = serviceInfor[i].count;

        newBlock.setAttribute('data-index', i);

        const deleteBtn = document.createElement('td');
        deleteBtn.className = 'delete-btn';
        deleteBtn.innerHTML = 'Delete';

        newBlock.appendChild(serviceNameValue);
        newBlock.appendChild(serviceQuantityValue);
        newBlock.appendChild(deleteBtn);

        serviceChosen.appendChild(newBlock);

        hideForm();

        deleteBtn.onclick = () => {
            const indexToDelete = parseInt(newBlock.getAttribute('data-index'));

            if (!isNaN(indexToDelete)) {
                serviceChosen.removeChild(newBlock);
                serviceInfor.splice(indexToDelete, 1);
                $.ajax({
                    url: '/RegistrationForm/GetMaDichVuByIndex',
                    type: 'GET',
                    data: { index: indexToDelete },
                    success: function (DichVu) {
                        if (DichVu) {
                            $.ajax({
                                url: '/RegistrationForm/DeleteService',
                                type: 'POST',
                                data: { maDichVu: DichVu.maDichVu },
                                success: function (data) {
                                    if (data.success) {
                                        console.log('Dịch vụ đã được xóa thành công.');
                                        resetView(serviceInfor);
                                    } else {
                                        console.log('Không thể xóa dịch vụ.');
                                    }
                                },
                                error: function () {
                                    console.log('Lỗi khi gửi yêu cầu xóa dịch vụ.');
                                }
                            });
                        }
                        else {
                            console.log('Mã dịch vụ không hợp lệ.');
                        }
                    },
                    error: function () {
                        console.log('Lỗi khi gửi yêu cầu lấy mã dịch vụ.');
                    }
                });
            }
        }
    }
}

if (addServiceForm) {
    const serviceInfor = [];

    addServiceBtn.onclick = () => {
        addServiceForm.style.display = "flex";

        const serviceName = addServiceForm.querySelector('.service-name')
        const serviceQuantity = addServiceForm.querySelector('.service-quantity');

        serviceName.value = null;
        serviceQuantity.value = null;

        submitService.onclick = () => {
            //var isNull = serviceInfor.every((service) => service.value != serviceName.value.trim());

            //if (isNull) {
            $.ajax({
                url: '/RegistrationForm/AddService',
                type: 'POST',
                data: {
                    maDichVu: serviceName.value,
                    soLuong: serviceQuantity.value
                },
                success: function (data) {
                    if (data) {
                        console.log("list service: ", data);
                    }
                }
            });

            var existingService = serviceInfor.find((service) => service.value === serviceName.value.trim());

            if (existingService) {
                existingService.count += parseInt(serviceQuantity.value.trim()) || 0;
            } else {
                serviceInfor.push({
                    value: serviceName.value.trim(),
                    count: parseInt(serviceQuantity.value.trim()) || 0,
                });
            }
            resetView(serviceInfor);
        };


        closeEvents.forEach(closeEvent => {
            closeEvent.addEventListener('click', () => {
                hideForm();
            });
        });

        serviceContainer.addEventListener('click', (e) => {
            e.stopPropagation();
        });
    }
}
