function calc(expressionString) {
    if (expressionString == "" || typeof(expressionString) != "string") {
        return "Wrong or empty string";
    }
    let numbersAndOpers = /[\+,\-,\*,\/,\=]{1}|\-?\d+(\.\d+)?/ig,
    matchArray = expressionString.match(numbersAndOpers),
    result = Number(matchArray[0]);
console.log(matchArray);
    for (var i = 1; i < matchArray.length; i++) {
        switch (matchArray[i]) {
            case "+": result += Number(matchArray[i + 1]); break;
            case "*": result *= Number(matchArray[i + 1]); break;
            case "-": result -= Number(matchArray[i + 1]); break;
            case "/": result /= Number(matchArray[i + 1]); break;
            case "=": break;
            default: continue;
        }
    }
    if (isNaN(result) || matchArray[matchArray.length - 1] != "=") {
        return `Wrong string : ${expressionString}`;
    }
    else {
    return expressionString + Number(result.toFixed(2));
    }
}

console.log(calc("10 / 5.5 + 13 * 5 = "));
console.log(calc("10 ++ 5 == "));
console.log(calc("привет + 5 = "));
console.log(calc("5 + 7 = 14"));
console.log(calc(""));
console.log(calc(5));