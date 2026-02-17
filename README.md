# Gilded Rose starting position in C# xUnit

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```

Gilded Rose
===========

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods. Unfortunately, our goods are constantly degrading in quality as they approach their sell by date. We have a system in place that updates our inventory for us. It was developed by a no-nonsense type named Leeroy, who has moved on to new adventures. Your task is to add the new feature to our system so that we can begin selling a new category of items. First an introduction to our system:

* All items have a SellIn value which denotes the number of days we have to sell the item
* All items have a Quality value which denotes how valuable the item is
* At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

* Once the sell by date has passed, Quality degrades twice as fast
* The Quality of an item is never negative
* "Aged Brie" actually increases in Quality the older it gets
* The Quality of an item is never more than 50
* "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
* "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert

We have recently signed a supplier of conjured items. This requires an update to our system:

* "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any new code as long as everything still works correctly. However, do not alter the Item class or Items property as those belong to the goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code ownership (you can make the UpdateQuality method and Items property static if you like, we'll cover for you). Your work needs to be completed by Friday, February 18, 2011 08:00:00 AM PST.

Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.

Resolution log
==============

This kata is being solved at the moment with Rider and the usage of GPT-4.1 in Microsoft Copilot suing its different
available modes.

No intructions.md yet.

### Setup

I wanted to start the kata with no previous scaffolding or testing ready.

So I kept only implementation code and readme and created the testing project with the assistance of an LLM agent.

My first prompt was:

```cmd
Create a test project to test GildedRose Program output using .NET Verify for xunit.
```

The LLM tried but what it was creating wasn't getting any output from the program and got stuck
in a loop of trying to fix setup.

It created a Unit Test and also a test with Verify library that allows you to compare program output.

I realized that the problem wasn't in the setup but that the number of iterations in the test was 0 and so it created
no output.

Instead of fixing I tried to ask the agent questions so it is aware about that. It was ... difficult.

There was also a missing package that was an impediment for getting an output form the tests.

### Generating enough output

A problem with a code you don't know well is how to choose what intput to give to get a full idea of what the software
does. In our case the input is sa set of products that represent that represwetn teh deiffernt natures of products in
the shop and then the number of days passed. So I asked the agent to suggest a number of days to see passing so we can
see all rules described in the README in action.

So, to start I asked:
```cmd
We want to get a full register of how the actual implementation of the program manages the passing of days and the
change in Quality. Given what is on README.MD how many days do you think we should observe given Program.cs input to see
all behavior described there.
```

Summarized output
```cmd
Conclusion
To capture all behaviors, observing the program for 20 days should be sufficient. This will ensure we see:
"Backstage passes" drop to 0.
"Aged Brie" potentially reaching its maximum quality.
"Conjured" items degrading completely.
General items degrading past their sell-by date.
Would you like me to adjust the test or program to observe for 20 days?
```

I asked it to modify the test and did right.

It suggested to directly accept the output as first verified output.

### Verifying output

However I was trusting the output of the software blindly. As it can happen in real legacy projects software behavior
may differ from documentation. So I thought a cool usage of an LLM agent would be to verify the output against the rules
described in the readme.

After some iterations it validated (correctly as I was checking myself the explanations with the verified output) but I
think it was quicker than doing it yourself.

It also detected the software still does not yet implement the Conjured rule that you're asked to introduce in the
README.

After that I changed the Verify output to "verified"

```cmd
As we're using Verify I'd like to copy the received content with teh current implementation output to the verified file
```
