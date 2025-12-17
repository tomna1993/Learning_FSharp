// let hypotenuse (a :float)  (b :float) :float = sqrt (a * a + b * b)
//
// let isEven a =
//     a % 2 = 0
//     
// let max3 (a:int) (b:int) (c:int) :int =
//     if a > b && a > c then a
//     elif b > a && b > c then b
//     else c
//     
open System.Linq

let celsiusToFahrenheit celsius =
    (celsius * 9.0/5.0) + 32.0
    
let fahrenheitToCelsius fahrenheit =
    (fahrenheit - 32.0) * 5.0/9.0
//
// let getName () = Console.ReadLine()
//
// let getAge () = Console.ReadLine()
//
// printfn $"{hypotenuse 8 6}"
//
// let even = if isEven 9 then "Even" else "Odd"
// printfn $"{even}"
//
// printfn $"{max3 3 2 1}"
//
// let celsius = -10
// let fahrenheit = celsiusToFahrenheit celsius
// printfn $"{celsius} celsius is {fahrenheit} fahrenheit"
//
// let fahrenheit2 = -10
// let celsius2 = fahrenheitToCelsius fahrenheit2
// printfn $"{fahrenheit2} fahrenheit is {celsius2} celsius"
//
// printf "Hello, please write your name: "
// let name : string = getName ()
// printf "Now write your age: "
// let age : string = getAge ()
//
// printfn $"Hello {name}, next year you will be {int age + 1}."










// let sign n =
//     match n with
//     | 0 -> 0
//     | _ when n > 0 -> 1
//     | _ -> -1
//
// let isEven n = n % 2 = 0
//
// let describeNumber n =
//     match n with
//     | 0 -> "zero"
//     | _ when n > 0 && isEven n -> "positive even"
//     | _ when n > 0 -> "positive odd"
//     | _ when n < 0 && isEven n -> "negative even"
//     | _ when n < 0 -> "negative odd"
//     
//     
// let parityToString n =
//     if isEven n then "Even" else "Odd"
//
// printfn $"{sign 5}"
// printfn $"{sign -7}"
// printfn $"{sign 0}"
//
// printfn $"{describeNumber 0}"
// printfn $"{describeNumber 1}"
// printfn $"{describeNumber 2}"
// printfn $"{describeNumber -1}"
// printfn $"{describeNumber -2}"
//
// printfn $"{parityToString 3}"
// printfn $"{parityToString 2}"








let emptyList = []
let numbersList = [1; 2; 3]
let charList = ['a'; 'b'; 'c']
let twoElementList = ["first"; "second"]

printfn $"{emptyList}"
printfn $"{numbersList}"
printfn $"{charList}"

let isEven n = n % 2 = 0

let describeList list =
    match list with
    | [] -> "Empty list"
    | [ x ] -> $"Head of the list is {x}"
    | [ x; y ] -> $"First element {x} and second element {y} of the list"
    | x :: xs -> $"First element {x} and has more {xs}"
    
let rec sum list =
    match list with
    | [] -> 0
    | x :: xs -> x + sum xs
    
let rec length list =
    match list with
    | [] -> 0
    | _ :: xs -> 1 + length xs
    
let rec product list =
    match list with
    | [] -> 1
    | x :: xs -> x * product xs
    
let rec contains num list =
    match list with
    | [] -> false
    | x :: xs -> if x = num then true else contains num xs
    
let rec countEvens list =
    match list with
    | [] -> 0
    | x :: xs -> if isEven x then 1 + countEvens xs else countEvens xs
    
printfn $"{describeList emptyList}"
printfn $"{describeList numbersList}"
printfn $"{describeList charList}"
printfn $"{describeList twoElementList}"

printfn $"Sum of list {numbersList} = {sum numbersList}"
printfn $"Length of list {numbersList} = {length numbersList}"
printfn $"Length of list {twoElementList} = {length twoElementList}"
printfn $"Length of empty list [] = {length emptyList}"

printfn $"Product of list {emptyList} = {product emptyList}"
printfn $"Product of list {numbersList} = {product numbersList}"

let number: int = 6
printfn $"Does list {numbersList} contain {number}? {contains number numbersList}"

printfn "There are %d even number in the list %A" (countEvens numbersList) numbersList











let numbersList2 = [0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15; 16; 17]
let rec filter p list =
    match list with
    | [] -> []
    | x :: xs ->
        if p x then
            x :: filter p xs
        else filter p xs

let evenList = filter isEven numbersList2
printfn "Old list is: %A, even numbers are: %A" numbersList2 evenList

let multiplyWithTwo n = n * 2

let rec map f list =
    match list with
    | [] -> []
    | x :: xs ->
        (f x) :: map f xs
        
let multipliedByTwo = map multiplyWithTwo numbersList2
printfn "Old list is: %A, even numbers are: %A" numbersList2 multipliedByTwo

let doubleList = map (fun x -> x * 2) numbersList
printfn "Old list is: %A, even numbers are: %A" numbersList doubleList

let strings = ["hello"; "tomas"; "kiskutya"; "aneszteziologus"]
let stringLengths = map String.length strings
printfn "String list is: %A, string lengths are: %A" strings stringLengths

let keepOdds list =
    list
    |> filter (fun x -> not (isEven x))

printfn "Odd numbers: %A" (keepOdds numbersList2)

let sumOfSquares list =
    list
    |> map (fun x -> x * x)
    |> sum
    
printfn "Sum of squares of list %A = %d" numbersList (sumOfSquares numbersList)


let doubleEvenNumbers list =
    list
    |> filter isEven
    |> map (fun x -> x * 2)
    
printfn "Even numbers are doubled: %A" (doubleEvenNumbers numbersList2)


let doubleAll (list:int list) : int list =
    list |> List.map (fun x -> x * 2)

printfn "Double list elements: %A" (doubleAll numbersList2)


let longStringLengths list =
    list
    |> map String.length
    |> filter (fun x -> x > 10)
    
printfn "Too long strings: %A" (longStringLengths strings)


let nonNegativeCelsiusToFahrenheit (temps:float list) : float list =
    // TODO:
    // 1. keep only temperatures >= 0.0
    // 2. convert them to Fahrenheit
    // use List.filter and List.map
    temps
    |> List.filter (fun x -> x >= 0.0)
    |> List.map celsiusToFahrenheit

let celsius = [-10.0; 0.0; 10.0; 25.0]

printfn "Result of conversion: %A" (nonNegativeCelsiusToFahrenheit celsius)

let listLengthFold list =
    list |> List.fold (fun acc _ -> acc + 1) 0
    
printfn $"Elements in the list: {listLengthFold numbersList}"
    
let productFold list =
    list |> List.fold (fun acc x -> acc * x) 1
    
printfn $"Product of elements: {productFold numbersList}"

let reverseList list =
    list |> List.fold (fun acc x -> x :: acc) []
    
printfn $"Reversed list: {reverseList numbersList2}"







let rec safeLookup p list =
        match list with
        | [] -> None
        | element :: _ when p element -> Some element
        | _ :: xs -> safeLookup p xs
        
let safeLookupWithListTryFind p list =
    list |> List.tryFind p
        
let numbers3 = [3; 5; 7; 9]        

let result = safeLookup isEven numbers3
match result with
| Some element -> printfn $"{element}"
| None -> printfn "There is no result"

let result2 = safeLookupWithListTryFind isEven numbers3
match result2 with
| Some element -> printfn $"{element}"
| None -> printfn "There is no result"


let numbersList3 = [2; 5; 1; 19; 3; 41; 8; 23; 1]
let numbersList4 = [-2; -5; -1; -5; -3; -41; -8; -23; -1]

let rec safeMaximum list =
    match list with
    | [] -> None
    | [ x ] -> Some(x)
    | x :: xs ->
            let number = safeMaximum xs
            match number with
            | Some y -> if x > y then Some(x) else Some(y)
            | None -> None
        
let result3 = safeMaximum numbersList3
match result3 with
| Some max -> printfn $"Maximum is: {max}"
| None -> printfn "There is no number in the list"


let safeMaximumWithFold list =
    list
    |> List.fold (fun acc elem ->
        match acc with
        | Some y -> 
            if y > elem then Some(y) else Some(elem)
        | None -> Some(elem)
        ) None

let result4 = safeMaximumWithFold numbersList4
match result4 with
| Some max -> printfn $"Maximum is: {max}"
| None -> printfn "There is no number in the list"


let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

let sumOfOdds list =
    list
    |> List.filter (fun x -> x % 2 <> 0)
    |> List.sum
    
printfn $"Sum of odds = {sumOfOdds numbers}"

    
let findElementIndex p list =
    
    let rec findIndex index currentList =
        match currentList with
        | [] -> None
        | x :: xs -> if p x then Some(index) else findIndex (index + 1) xs
    
    findIndex 0 list
    
    
// Example 1:
let isGreaterThanFive n = n > 5
// Expected: Some(2) (because 7 is at index 2)

// Example 2:
let numbers2 = [1; 2; 3; 4]
let result5 = findElementIndex isGreaterThanFive numbers
match result5 with
| Some x -> printfn "Index of grater then 5 number in list is: %i" x
| None -> printfn "There is no number in the list greater then 5"


let strings2 = ["apple"; "banana"; "cherry"; "date"]

let capitalizeFirstLetter (s :string) :string =
    let firstLetter :string = s.[0].ToString().ToUpper()
    let restLetters = s.Substring(1)
    firstLetter + restLetters
        
let capitalizeList (list :string list) :string list= 
    list
    |> List.map (capitalizeFirstLetter)
    
printfn "%A" (capitalizeList strings2)

     
// Example: capitalizeList strings should return ["Apple"; "Banana"; "Cherry"; "Date"]
    
    
    
let partitionList1 p list =
    list
    |> List.fold (fun (partitioned, wrong) elem ->
        if p elem then (elem :: partitioned, wrong)
        else (partitioned, elem :: wrong)
        ) ([], [])
    
    |> fun (partitioned, wrong) ->
        (partitioned |> List.rev, wrong |> List.rev)
    
let result6 = partitionList1 isEven numbersList2
    
match result6 with
| (partitioned, wrong) -> printfn "Partitioned are: %A, wrongs are: %A" partitioned wrong




let partitionList2 p list =
    List.foldBack (fun elem (partitioned, wrong) ->
        if p elem then (elem :: partitioned, wrong)
        else (partitioned, elem :: wrong)
        ) list ([],[])
    
let result7 = partitionList2 isEven numbersList2
match result7 with
| (partitioned, wrong) -> printfn "Partitioned are: %A, wrongs are: %A" partitioned wrong

let result8 = List.partition isEven numbersList2
match result8 with
| (partitioned, wrong) -> printfn "Partitioned are: %A, wrongs are: %A" partitioned wrong