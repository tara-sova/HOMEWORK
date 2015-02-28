let rec multiply number = 
    if (number = 0) then 1
    else
        (number % 10) * (multiply(number / 10))
multiply 32;;