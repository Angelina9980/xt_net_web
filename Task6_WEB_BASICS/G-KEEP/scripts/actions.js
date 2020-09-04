
let id; 
let bodyInFrontOfNotes;

if (localStorage.length != 0) {
    for (let i = 0; i < localStorage.length; i++) {
        let list = localStorage.getItem(i);
        let noteData = JSON.parse(list);
        console.log(noteData);
        ShowNote(i, noteData.title, noteData.text);
    }
}
else {
        id = 0;
    }

let createButton = document.getElementById('create-button');
let closeButton = document.getElementsByClassName('close-button')[0];
let newNoteButton = document.getElementById('create-note');
let changeNoteButton = document.getElementById('save-note');

let wrapper = document.getElementById('wrapper');
let modal = document.getElementById('create-modal');
let changeModal = document.getElementById('change-modal');

//localStorage.clear();


createButton.onclick = function () {
    modal.style.display = 'block';
    wrapper.style.opacity = 0.5;
}

closeButton.onclick = function() {
    modal.style.display = 'none';
    wrapper.style.opacity = 1;
}

newNoteButton.onclick = function() {
    createNote();
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

function ShowNote(id, title, text) {
    bodyInFrontOfNotes = document.getElementById('bodyInFrontOfNote');
    bodyInFrontOfNotes.insertAdjacentHTML("afterend", `<div class = "noteBody" id = ${id}>
        <input type="text" id="note-title" value = "${title}" disabled>
        <textarea name="text" id = "note-content" disabled>${text}</textarea>
        <button class="delete-button"></button></div>`);
        
        let deleteButton = document.getElementsByClassName('delete-button')[0];
        let note = document.getElementsByClassName('noteBody')[0];

        deleteButton.onclick = function() {
            if (confirm("Вы действительно хотите удалить заметку?")) {
                note.parentNode.removeChild(note);
                localStorage.removeItem(note.id);
            }
        }
}

function addToStorage (id, noteTitle, noteText) {
    const elem = {
        title: noteTitle,
        text: noteText
    }
    localStorage.setItem(id, JSON.stringify(elem));
}
