# The Ray Tracer Challenge - Implementing primitives and vector algebra operations

After setting up the project time to start implementing the code for the first chapter of the book, which focus mostly on defining primitives (Point and Vectors), and vector algebra operations like sum, subtraction and also dot and cross products.

## Challenges encountered

At first it looked a simple task: how hard could it be to write some methods to perform simple addition, substractions and some other basic formulas?

But it was not. 

### "Re-learning" vector algebra

The first main challenge was "re-learning" vector algebra, and meaning of the various operations. The book explained well enough for the purpose of the implementation, but I wanted to understand a bit more, and Wikipedia helped a lot. Here some intersting links I found:

 * [Euclidean vector](https://en.wikipedia.org/wiki/Euclidean_vector)
 * [Dot product](https://en.wikipedia.org/wiki/Dot_product)
 * [Cross product](https://en.wikipedia.org/wiki/Cross_product)

### Modeling the primitives

The main primitive in the 3D space is a Tuple (of 4 elements), with the 3 coordinates (`x`, `y`, `z`) and a value (`w=0 or 1`) to identify it as either a vector or a point. I dotup;n't know if this is a standard approach of just something the author of the book came up with. And also in chapter 1 the reasoning is not explained well, but refers to later in the book. 

#### Inheritance

I initallly implemented the primitives as a `Tuple` class, that implements all common operations, and the two subclasses, `Point` and `Vector`, to more easily create tuples without having to remember the `w` parameter. It all went fine in the implementation of the library, but things started to fail in the first exercise. The reason is that, adding a `Point` to a `Vector` should produce a `Point`. But with this inheritance scheme, that addition will create a `Tuple` that cannot be casted to a `Point`. It took me a while to understand that there was no way around this problem, so you can see far I went before getting stuck, on my repo, on branch [Chapter 1.2](https://github.com/simonech/ray-tracer-challenge-netcore/tree/Chapter-1.2).

```
Add some example
```

#### Inner value

Another option I experimented with is the usage on an inner property. So both `Point` and `Vector` have an "innerValue" object of type `Tuple` on which all operations are done.

```
Add some example
```

#### Just the Tuple

The next option is just using the `Tuple` with 2 static factory methods to create tuples that are points (`w=1`) or vectors (`w=0`). We lose the possibility of limiting some operations to either point or vectors, but we don't encounter casting issues. And this is also the approach the book suggests.

```
Add some example
```

Eventually I decided to use...

### Which data type to use

The book suggests to use a "native" floating point data type, since these values will be used a lot. I decided to use a `double`, even if probably a `float` would enough, to avoid lots of casting given that all the `System.Math` work with `Double` types.

