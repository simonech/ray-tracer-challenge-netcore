# Which is the fastest string concatenation method, String.Join or StringBuilder? - Bonus post from The Ray Tracer Challenge series


Everyone knows that you don't concatenate strings with `myString += " more text"`, but that you should always use a `StringBuilder` to do it. Is it always the case? What about the `Sting.Join`? Is it faster or slower? In this post, I'm going to share what I've discovered while experimenting with BenchmarkDotNet.

In the context of my The Ray Tracer Challenge, I wanted to take a moment of reflection after having implemented the basic primitives and the image serialization code. In the next chapters of the book, I'll be using those primitives a lot, and before moving on, I wanted to make sure I implemented them in the most efficient way possible (within the "rules" of the challenge).

I downloaded BenchmarkDotNet, the "micro-benchmark" library developed by Microsoft to test the performances of the .NET Core framework, and started to get accustomed to it. Before targeting my library, I started testing, as exploratory exercise, which was the fastest string concatenation method among the following:

 - `+=` approach (I knew it was slower, but how much slower?)
 - `String.Join`
 - `StringBuilder`

After running the tests, I created a poll on Twitter, asking what people thought was the fastest method. I got 34 votes, and 53% answered `StringBuilder` and 47% answered `String.Join` (18 vs. 16).

[Robbie Bett](https://twitter.com/TeeSpirit) commented, saying: "It depends. Probably `String.Join` with a little number of iterations or small strings added up and `StringBuilder` with longer iterations and bigger size of the string appended" (original text modified for readability).

Enough talking. Here is what I discovered.

## When String.Join is faster than StringBuilder

Like most things in software development, the answer is: **it depends**.

 - `StringBuilder` is the clear winner when the number of iterations is higher than 1000, no matter the size of the string appended. It is also always faster when the size of the strings appended is very small (1, 2, and 4).
 - `Sting.Join` is faster when the size of the string is bigger (8 to 64 characters) and the number of iterations is less than 1000.

I think the results are a bit counterintuitive, considering that `String.Join` is implemented using a `StringBuilder`.

So I decided to dig deeper into the performances of `String.Join`, and I also tested the other overloads:

 - `Join<T>(String separator, IEnumerable<T> values)`
 - `Join(String separator, params Object[] values)`
 - `Join(String separator, IEnumerable<String> values)`

To test these method I created a simple class, with a custom `ToString` method. I also added an additional benchmark, where I iterated over the list, and used the `StringBuilder` to concatenate the strings, to asses the penalty of calling a `ToString` method instead of accessing the string directly.

Unsurprisingly, since the `Join` over objects is implemented using a `StringBuilder`, the overload with the `Object` array took the same amount of time of the benchmark performed directly on the array of string. The methods that used the `IEnumerable`, where slower, around 20% slower.

## How much slower is the normal concatenation of strings?

Another statement I wanted to verify was how much slower is the `+=` approach. Well, it is immensively slower. With the smallest parameters (1 character and just 5 iterations), it is twice as slow as `Join` and 5 time slower than the `StringBuilder` (150ns vs. 71ns vs. 30ns). With the biggest parameters (10000 iterations of strings of 64 chars) it is 10000 times slower than the `StringBuilder` and 3500 times slower than `Join` (2,5sec vs 0,25ms vs 0,7ms). 

## The code

