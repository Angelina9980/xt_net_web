
function showRemoving(text) {
let words = text.split(' '),
repeatLetters = "",
result = "";

if (words.length < 2 || typeof(text) != "string") {
console.log(`Wrong or empty string: ${text}`);
}
else {
words.forEach(word => {
    let letters = word.split('');
    letters.forEach(letter => {
        let repeat = 0;
        letters.forEach(nextLetter =>{
            if (letter == nextLetter){
                repeat++;
            }
            if (repeat > 1){
                repeatLetters+=letter;
            }
        });
    });
});

if (repeatLetters == "") {
console.log(`The string remains unchanged: ${text}`);
}
else {
text.split('').forEach(elem => {
    if (!repeatLetters.includes(elem)){
        result+=elem;
    }
});
}
console.log(result);
}
}
showRemoving("");
showRemoving("У попа была собака");
showRemoving("5567");
showRemoving("Буря мглою небо кроет");