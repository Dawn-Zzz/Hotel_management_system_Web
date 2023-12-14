
'use strict';

const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);

const guestTable = $('.guest-table');
const staffTable = $('.staff-table');
const addRoomBtn = $('#add-room-btn');
const addServiceBtn = $('#add-service-btn');
const addRoomForm = $('.add-room-form');
const addServiceForm = $('.add-service-form');
const submitBtn = $('.submit-form-btn'); 
const submitRoom = $('.submit-room');
const submitService = $('.submit-service');
const closeEvents = $$('.close-btn, .room-form');
const roomContainer = $('.room-container');
const serviceContainer = $('.service-container');
const roomChosen = $('.room-chosen');
const serviceChosen = $('.service-chosen');

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
                        <td>${index+1}</td>
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
                        <td>${index+1}</td>
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

const familyRoomList = $('.family-room-list');
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
    addRoomForm.style.display = "none";
    addServiceForm.style.display = "none";
}

if (addRoomForm) {
    const roomInfor = [];
    addRoomBtn.onclick = () => {
        console.log(addRoomForm);
        addRoomForm.style.display = "flex";
        //const roomNode = e.target.closest('.room');
        //if (roomNode) {

        //const typeOfRoom = roomNode.querySelector('.room-type');
        //const imgPath = roomNode.querySelector('.img-fluid');

        const roomID = addRoomForm.querySelector('.room-id')
        const roomNumber = addRoomForm.querySelector('.room-number');
        const clienQuantity = addRoomForm.querySelector('.clien-quantity');
        //const clientPhoneNumber = addRoomForm.querySelector('.client-phone-number');
        //const clientEmail = addRoomForm.querySelector('.client-email');
        //const clientCheckIn = addRoomForm.querySelector('#checkin_booking');
        //const clientCheckOut = addRoomForm.querySelector('#checkout_booking');
        //const clientAdults = addRoomForm.querySelector('.adults-number');
        //const clientChildren = addRoomForm.querySelector('.children-number');

        roomID.value = null;
        roomNumber.value = null;
        clienQuantity.value = 0 ;
        //clientCheckIn.value = null;
        //clientCheckOut.value = null;
        //clientAdults.value = null;
        //clientChildren.value = null;

        //formImage.style.background = `url('${imgPath.src.slice(23)}') top center / cover no-repeat`;

        submitRoom.onclick = () => {

            while (roomInfor.length > 0) {
                roomInfor.pop();
            }
            roomInfor.push(
                roomID.value,
                roomNumber.value,
                clienQuantity.value,
            //    clientCheckIn.value,
            //    clientCheckOut.value,
            //    clientAdults.value,
            //    clientChildren.value
            );
            var isNull = roomInfor.every((clientValue, index) => {
                return clientValue != "";
            });
            if (isNull) {
                roomChosen.innerHTML += `
                    <p>${roomID.value}</p>
                    <p>${roomNumber.value}</p>
                    <p>${clienQuantity.value}</p>
                    <p class="add-btn delete-btn">Delete</p>
                `
                hideForm();
                console.log(roomInfor);
            }
        }

        //formTitle.textContent = typeOfRoom.textContent;
        closeEvents.forEach(closeEvent => {
            closeEvent.addEventListener('click', () => {
                roomInfor.push(
                    roomID.value,
                    roomNumber.value,
                    clienQuantity.value,
                //    clientCheckIn.value,
                //    clientCheckOut.value,
                //    clientAdults.value,
                //    clientChildren.value
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
        //}
    }
}

if (addServiceForm) {
    const serviceInfor = [];
    addServiceBtn.onclick = () => {
        console.log(addServiceForm);
        addServiceForm.style.display = "flex";
        //const roomNode = e.target.closest('.room');
        //if (roomNode) {

        //const typeOfRoom = roomNode.querySelector('.room-type');
        //const imgPath = roomNode.querySelector('.img-fluid');

        const serviceName = addServiceForm.querySelector('.service-name')
        const serviceQuantity = addServiceForm.querySelector('.service-quantity');
        //const clientName = addServiceForm.querySelector('.client-name');
        //const clientPhoneNumber = addServiceForm.querySelector('.client-phone-number');
        //const clientEmail = addServiceForm.querySelector('.client-email');
        //const clientCheckIn = addServiceForm.querySelector('#checkin_booking');
        //const clientCheckOut = addServiceForm.querySelector('#checkout_booking');
        //const clientAdults = addServiceForm.querySelector('.adults-number');
        //const clientChildren = addServiceForm.querySelector('.children-number');

        serviceName.value = null;
        serviceQuantity.value = null;
        //clientEmail.value = null;
        //clientCheckIn.value = null;
        //clientCheckOut.value = null;
        //clientAdults.value = null;
        //clientChildren.value = null;

        //formImage.style.background = `url('${imgPath.src.slice(23)}') top center / cover no-repeat`;

        submitService.onclick = () => {

            while (serviceInfor.length > 0) {
                serviceInfor.pop();
            }
            //clientInfo.push(
            //    clientName.value,
            //    clientPhoneNumber.value,
            //    clientEmail.value,
            //    clientCheckIn.value,
            //    clientCheckOut.value,
            //    clientAdults.value,
            //    clientChildren.value
            //);
            var isNull = serviceInfor.every((clientValue, index) => {
                return clientValue != "";
            });
            if (isNull) {
                serviceChosen.innerHTML += `
                    <p>${serviceName.value}</p>
                    <p>${serviceQuantity.value}</p>
                    <p class="add-btn delete-btn">Delete</p>
                `
                hideForm();
            }
            else {
                console.log("error");
            }
        }

        //formTitle.textContent = typeOfRoom.textContent;
        closeEvents.forEach(closeEvent => {
            closeEvent.addEventListener('click', () => {
                serviceInfor.push(
                    serviceName.value,
                    serviceQuantity.value,
                //    clientEmail.value,
                //    clientCheckIn.value,
                //    clientCheckOut.value,
                //    clientAdults.value,
                //    clientChildren.value
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
        serviceContainer.addEventListener('click', (e) => {
            e.stopPropagation();
        });
        //}
    }
}
