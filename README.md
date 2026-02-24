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

Day 1

This kata is being solved at the moment with Rider and the usage of GPT-4.1 in Microsoft Copilot using its different
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

However I wasn't trusting the output of the software blindly. As it can happen in real legacy projects software behavior
may differ from documentation. So I thought a cool usage of an LLM agent would be to verify the output against the rules
described in the readme.

After some iterations it validated (correctly as I was checking myself the explanations with the verified output) but I
think it was quicker than doing it yourself.

It also detected the software still does not yet implement the Conjured rule that you're asked to introduce in the
README.

After that I changed the Verify output to "verified"

```cmd
As we're using Verify I'd like to copy the received content with the current implementation output to the verified file
```

Day 2

### Planning refactor

I tried to prompt the Agent mode with GPT 4.1 with this:
```cmd
Identify the first most simple refactor that would help us introduce a new special behavior that is that Items that
start by Conjured degrade twice as fast.
```

My intention was that it started refactoring easy refactorings however it jumped right to try to solve the problem by
extracting a degradation rate variable. 

It took some prompts to redirect it to prioritize making teh code human maintainable and extensible and not just fixing
the problem.

First I set clear limits:

```cmd
I asked for a refactor not for you to introducet the new functionality. We need some discipline!
Please don't add newbehavior when I ask for refactor.
```

However it insisted in extracting the degradation rate as the shortest refactor so I had to try a different way.
It ran the errors tool and mentioned all the warnings present. Some of them coming from the local Sonar plugin I have.

So I asked:

```cmd
I this had to be maintained by humans which of those warnigns would worry you more? More than extracting the degradation
rate.
```

Response:
```cmd
If this code had to be maintained by a team, the warning that would worry me most—more than extracting the degradation rate—would be the high cognitive complexity of the UpdateQuality method. The warning says:
Refactor this method to reduce its Cognitive Complexity from 69 to the 15 allowed.
This means the method is very difficult to read, understand, and safely modify. It has deeply nested conditionals and repeated logic, which increases the risk of bugs and makes future changes (like adding new item behaviors) much harder and error-prone.
Addressing cognitive complexity is more important for maintainability than extracting the degradation rate, because it improves clarity, reduces duplication, and makes the codebase safer for future refactors and feature additions.
```

Then I asked:
```cmd
SO what is the recommendde course fo action to keep the code human maintainable?
```

Response:
```cmd
ow:
Extract Item-Specific Logic: Move the rules for each item type (e.g., “Aged Brie”, “Sulfuras”, “Backstage passes”, normal items) into separate methods or classes. This is often done using the Strategy or Polymorphism pattern, where each item type has its own update logic.
Flatten Nested Conditionals: Reduce deep nesting by using early returns or guard clauses, and by separating concerns.
Clarify Intent: Use descriptive method names and variables to make the code’s purpose clear.
Avoid Magic Strings: Replace repeated item name strings with constants or enums.
Unit Test Coverage: Ensure each item rule is covered by tests, so changes are safe.
Summary of steps:
Refactor UpdateQuality to delegate to item-specific update methods.
Create a structure (e.g., ItemUpdater classes) for each item type.
Make the main loop simple: for each item, call its updater.
This will make the code much easier to read, modify, and extend for new behaviors (like “Conjured”), and will reduce the risk of bugs. This is the most important maintainability improvement for this codebase.
```

Finally I asked it to come up with applan to rder refactors by risk and run teh verification tests after each step and
stop.

```cmd
Can you order this refactors from less risky to more risky?
```

Risk assessment output
```cmd
Here’s an ordered list of the recommended refactors for your GildedRose.cs code, from less risky to more risky:

Extract Magic Strings to Constants
Replace item name strings (e.g., "Aged Brie", "Sulfuras, Hand of Ragnaros") with constants.
Risk: Very low. No logic changes, just improves readability and reduces typo risk.

Extract Degradation Rate to Variable
Use a variable for the quality degradation rate (e.g., degradeRate = 1).
Risk: Low. No behavior change, just prepares for future extensibility.

Flatten Nested Conditionals
Use guard clauses or early returns to reduce nesting.
Risk: Low to moderate. If done carefully, logic remains unchanged, but mistakes in restructuring could alter flow.

Rename Fields and Parameters for Clarity
Rename Items to _items (field) and items (parameter) to follow conventions.
Risk: Low. Only affects naming, but could break code if not updated everywhere.


Extract Item-Specific Logic to Methods
Move logic for each item type into separate methods.
Risk: Moderate. Increases code clarity, but mistakes in extraction could change behavior.

Introduce Polymorphism/Strategy Pattern
Create classes or strategies for each item type, and delegate update logic.
Risk: High. Major structural change; if not covered by tests, could introduce bugs.

Refactor UpdateQuality to Use Item Updaters
Make UpdateQuality loop simple, calling an updater for each item.
Risk: High. Relies on correct implementation of updaters; large refactor.
```

```cmd
Okay then apply this refactors one by one and run the unit tests in between. Stop after running the tests every time.
```

Day 3

### Executing refactor

It applied the first refactor in the list successfully. However after that it started suggesting a refactor not present
in the list.

I asked it to incorporate the new refactor idea to the least and re-assess riskiness of all proposed refactors together
with it.

The new refactor list

```cmd
1. Introduce a local variable for Items[i] (already performed):
Reduces repetition and improves readability.
No logic change, extremely low risk.

2. Extract magic strings to named constants (already present):
Already done in your code for item names.
No logic change, very low risk.

3. Extract degradation logic into a helper method:
Encapsulates the “degrade quality” logic, making it easier to change or extend.
Slight risk if the extraction is not done carefully, but minimal if done as a pure refactor.

4. Extract item-specific logic into separate methods:
For example, methods for updating Aged Brie, Backstage Passes, Sulfuras, etc.
Increases modularity, but introduces more moving parts and indirection.

5. Introduce polymorphism (subclassing or strategy pattern for item types):
Each item type gets its own class or strategy for updating quality.
Most powerful for maintainability and extensibility, but highest risk due to structural changes and possible subtle bugs.
```

That shows us the nuance that although plans may be good, plans are laid out over a context that changes just after the
first step of the plan has been executed. This shows LLM results are also affected by the evolutionary nature of
software development.

```cmd
Apply refactors one by one. check if they've been performed. Run test and wait for confirmation from me that I want it
applied or for more feedback then continue with the next refactor.
```

I asked again. I changed the prompt a bit as I saw I've canceled the agent diff but it kept understanding that its
refactor was already applied

It applied the first (actually the first in the new list) introducing a local variable item for Items[i] refactor flawlessly.

It also applied the third (extracting the quality degradation logic into a helper method DegradeQuality) flawlessly.

It also applied the forth extracting item-specific logic for Aged Brie and Backstage Passes into separate methods.










