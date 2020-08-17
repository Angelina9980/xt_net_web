
function showRemoving(text) {
    if (typeof(text) != 'string') {
        return `The entered data is not a string : ${text}`;
    }
    let words = text.split(' '),
    repeatLetters = "",
    result = "";
    
    if (words.length < 2) {
        return `Wrong string: ${text}`;
    }
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
return `The string remains unchanged: ${text}`;
}
else {
text.split('').forEach(elem => {
    if (!repeatLetters.includes(elem)){
        result+=elem;
    }
});
}
return result;
}
console.log(showRemoving(""));
console.log(showRemoving("У попа была собака"));
console.log(showRemoving("5567"));
console.log(showRemoving("Буря мглою небо кроет"));
console.log(showRemoving(5));