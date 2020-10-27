let feedBackButton = document.getElementById('FeedBackButton'),
    pageBody = document.getElementsByClassName('pageBody')[0];

feedBackButton.onclick = function () {
    let feedBackModal = document.getElementsByClassName('cover')[0],
        closeModalButton = document.getElementById('close-button');

    feedBackModal.style.display = 'block';
    pageBody.style.opacity = 0.5;

    closeModalButton.onclick = function () {
        feedBackModal.style.display = 'none';
        pageBody.style.opacity = 1;
    }
}