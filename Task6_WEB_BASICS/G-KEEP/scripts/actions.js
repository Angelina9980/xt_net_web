
let id;
let bodyInFrontOfNotes;

if (localStorage.length != 0) {
    for (let i = 0; i < localStorage.length; i++) {
        let list = localStorage.getItem(i);
        let noteData = JSON.parse(list);
        ShowNote(i, noteData.title, noteData.text, noteData.deleted);
        console.log(noteData.deleted);
    }
}
else {
        id = 0;
    }

let createButton = document.getElementById('create-button');
let changeNoteButton = document.getElementById('save-note');
let resetButton = document.getElementById('reset-button');
let wrapper = document.getElementById('wrapper');

createButton.onclick = function () {
    wrapper.insertAdjacentHTML("afterend", `<div id="create-modal" class="modal">
    <input type="text" placeholder="Введите заголовок" id="modal-title">
    <textarea name="text" placeholder="Текст заметки" id = "modal-content"></textarea>
       <button id="create-note">Создать</button>
       <button class="close-button">Закрыть</button>`);
       let newNoteButton = document.getElementById('create-note');
       let closeButton = document.getElementsByClassName('close-button')[0];
       let modal = document.getElementById('create-modal');
       modal.style.display = 'block';

       newNoteButton.onclick = function() {
           createNote();
           modal.style.display = 'none';
           wrapper.style.opacity = 1;
       }
       
    closeButton.onclick = function() {
    modal.style.display = 'none';
    wrapper.style.opacity = 1;
}

function createNote() {
    let noteTitle = document.getElementById('modal-title').value;
    let noteText = document.getElementById('modal-content').value;

    if ((noteTitle.length || noteText.length != 0)) {
        addToStorage(id,noteTitle, noteText);
        ShowNote(id, noteTitle, noteText);
        id++;
    }
}
    wrapper.style.opacity = 0.3;
}

resetButton.onclick = function() {
    if (confirm("Вы действительно хотите очистить заметки?")) {
        localStorage.clear();
        window.location.reload();
    }
}


function ShowNote(id, title, text, deleted) {
    if (!deleted) {
    bodyInFrontOfNotes = document.getElementById('bodyInFrontOfNote');
    bodyInFrontOfNotes.insertAdjacentHTML("afterend", `<div class = "noteBody" id = ${id}>
        <input type="text" id="note-title" value = "${title}" disabled>
        <textarea name="text" id = "note-content" disabled>${text}</textarea>
        <button class="delete-button"></button></div>`);
        
        let deleteButton = document.getElementsByClassName('delete-button')[0];
        let note = document.getElementsByClassName('noteBody')[0];
    
        note.onclick = function(event){
            let title = note.querySelector('input').value;
            let text = note.querySelector('textarea').value;

            console.log(title, text);
            if (event.target != deleteButton) {
                wrapper.insertAdjacentHTML("afterend", `<div id="change-modal" class="modal">
                <input type="text" placeholder="Введите заголовок" value = "${title}" id="change-title">
                <textarea name="text" placeholder="Текст заметки" id = "change-content">"${text}"</textarea>
                <button id="save-note">Сохранить</button>
                <button class="close-button">Закрыть</button></div> `);

                let changeModal = document.getElementById('change-modal');
                changeModal.style.display = 'block';
                wrapper.style.opacity = 0.3;
            
            let closeChangeModalButton = document.getElementsByClassName('close-button')[0];

                closeChangeModalButton.onclick =  function() {
                changeModal.style.display = 'none';
                wrapper.style.opacity = 1;
                }

            let changeNote = document.getElementById('save-note');


            }
        }
        deleteButton.onclick = function() {
            if (confirm("Вы действительно хотите удалить заметку?")) {
                note.parentNode.removeChild(note);
                let deletedNote = localStorage.getItem(note.id);
                let JSONdeletedNote = JSON.parse(deletedNote);
                JSONdeletedNote.deleted = true;
                localStorage.setItem(note.id, JSON.stringify(JSONdeletedNote));
            }
        }
    }
}

function addToStorage (id, noteTitle, noteText) {
    const elem = {
        title: noteTitle,
        text: noteText,
        deleted: false
    }
    localStorage.setItem(id, JSON.stringify(elem));
}
