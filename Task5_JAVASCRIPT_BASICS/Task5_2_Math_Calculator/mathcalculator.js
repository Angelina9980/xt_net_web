function calc(expressionString) {
    let result = 0,
    numbersAndOpers = /[\+,\-,\*,\/,\=]{1}|\-?\d+(\.\d+)?/ig,
    matchArray = expressionString.match(numbersAndOpers);
    
    if (Number(matchArray[0]) + "" !== "NaN") {
        result += Number(matchArray[0]);
    }

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
    
    console.log(expressionString + Number(result.toFixed(2)));
}

calc("10 / 5.6 + 13.3 * 5 = ");