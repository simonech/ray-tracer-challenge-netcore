# The Ray Tracer Challenge... in .NET Core

I just bought book [The Ray Tracer Challenge - A Test-Driven Guide to Your First 3D Renderer](https://amzn.to/2Elaxkr) and in the upcoming months I'll be developing my own ray tracer, in .NET Core.

I will also document my learning experince on the blog, for me, to keep track of my progress, and maybe discuss some implementation decision with you, my readers, but also to share what I learn in the process.

## Why am I doing it

Nowadays I spend most of my time building CMS-based projects, using APIs provided by vendors, and aggregating results coming from Cloud-based services. And I stopped enjoying development.

I needed a change, I needed to find back my love for developing, and I needed to challenge myself to learn something new. The book teaches the theory of a ray tracing, and, using a TDD approach, makes you implement, from scratch, all the pieces needed: starting from basic vector and matrix computations, to image processing and storing, and finally going into the real-deal of rendering 3D scenes from scratch.

Rebuilding all the basic primitives might sound silly at first, in the current development world were developers reuse code and packages even for simple tasks as adding padding to strings. But the goal of the book is to help you redescover the fun of developing from scrath, doing things yourself, without relying on stuff done by others.

## Technologies used

The project will be implemented with .NET Core 2.2, with no external libraries, to adhere the most to the concept of the book, which is to build everything from scratch, even features that might exist already as part of .NET Standard or in other packages, like `Color`, `Point`, image rendering and serializing.

My objective is also to build everything using a Mac, the `dotnet` CLI and VS Code, to prove (mostly to myself) that this is a feasible approach, and that you can do everything you need without the full-blown Visual Studio.

I'll also try to use the latest features of the C# language, whenever makes sense.

The book recommends the usage of Cucumber for the testing, and even provides the full set of features in Gherkin. SpecFlow is the only Gherkin implementation for .NET, but seems like the support for .NET Core is not very advanced, and still relies on their Visual Studio plugin for generating the test files. So I'll start with plain old unit testing with xUnit, and will move to SpecFlow later.

## What I'll be learning

Such a project will involve a lot of learning: I will learn new things, improve the knowledge I have and, since there is a lot of math involved, I will re-learn things I've learned at the university.

Specifically, things I hope to learn better are:

 * Obviously, how raytracing works;
 * Math, Algebra, Matrix, Vectors and similar stuff;
 * usage of the `dotnet` CLI;
 * a more advanced usa of VS Code (now I mostly use it "just" as text editor);
 * New features of C# (with new I mean from v6 onwards);
 * xUnit;
 * BDD with Gherkin and SpecFlow.

## Show me the code

All code is hosted on Github: https://github.com/simonech/ray-tracer-challenge-netcore.

The repository will also include the posts of the series. To familiarize yourself with the structure of the repository, please have a look at the [README](https://github.com/simonech/ray-tracer-challenge-netcore/blob/master/README.md) file.

## Table of Content

I'll try to write a post at least once per chapter of the book, and document how things are going, the challenges I faced and what I learend. I will update this table of content with every post published

 * The Ray Tracer Challenge... in .NET Core - Introduction (this post)
 * [The Ray Tracer Challenge - Setting up the project]()

I hope you will subscribe to my blog (if you don't have already) and will learn together with my how implementing ray tracing in .NET Core.