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
    addRoomForm.style.display = "none";
    //addServiceForm.style.display = "none";
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
        clienQuantity.value = 0;
        //clientCheckIn.value = null;
        //clientCheckOut.value = null;
        //clientAdults.value = null;
        //clientChildren.value = null;

        //formImage.style.background = `url('${imgPath.src.slice(23)}') top center / cover no-repeat`;
        var blockIndexes = [];
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
                $.ajax({
                    url: 'AddBookRoom',
                    type: 'POST',
                    data: {
                        maPhong: roomNumber.value,
                        soNguoiO: clienQuantity.value
                    },
                });
                var newBlock = document.createElement('div');

                var roomIDValue = document.createElement('p');
                var roomNumberValue = document.createElement('p');
                var clientQuantityValue = document.createElement('p');

                roomIDValue.innerHTML = roomID.value.trim();
                roomNumberValue.innerHTML = roomNumber.value.trim();
                clientQuantityValue.innerHTML = clienQuantity.value.trim();

                newBlock.className = 'roomBlock';

                var deleteBtn = document.createElement('p');
                deleteBtn.className = 'delete-btn';
                deleteBtn.className = 'add-btn';
                deleteBtn.innerHTML = 'Delete';

                deleteBtn.onclick = () => {
                    var i = blockIndexes.indexOf(newBlockIndex);
                    if (i !== -1) {
                        blockIndexes.splice(i, 1);
                    }
                    roomChosen.removeChild(newBlock);
                    printBlockElements();
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
                }

                var newBlockIndex = blockIndexes.length;
                blockIndexes.push(newBlockIndex);

                newBlock.appendChild(roomIDValue);
                newBlock.appendChild(roomNumberValue);
                newBlock.appendChild(clientQuantityValue);
                newBlock.appendChild(deleteBtn);

                hideForm();

                roomChosen.appendChild(newBlock);

                printBlockElements();
            }
        }

        function printBlockElements() {
            var blockElements = document.getElementsByClassName('roomBlock');
            console.clear();

            // Loop qua các phần tử và in ra thông tin cùng index
            for (var i = 0; i < blockElements.length; i++) {
                var blockElement = blockElements[i];
                var index = blockIndexes[i];
                console.log('Block ' + i + ': ' + blockElement.childNodes[1].textContent);
                console.log(i);
                console.log(blockElement.childNodes[1].textContent);
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
                var newBlock = document.createElement('div');

                var serviceNameValue = document.createElement('p');
                var serviceQuantityValue = document.createElement('p');

                serviceNameValue.innerHTML = serviceName.value;
                serviceQuantityValue.innerHTML = serviceQuantity.value;

                newBlock.className = 'serviceBlock';

                var deleteBtn = document.createElement('p');
                deleteBtn.className = 'delete-btn';
                deleteBtn.className = 'add-btn';
                deleteBtn.innerHTML = 'Delete';

                deleteBtn.onclick = () => {
                    serviceChosen.removeChild(newBlock);
                }

                newBlock.appendChild(serviceNameValue);
                newBlock.appendChild(serviceQuantityValue);
                newBlock.appendChild(deleteBtn);

                hideForm();

                serviceChosen.appendChild(newBlock);
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