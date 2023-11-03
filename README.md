# SlotMachine

A simple and fun slot machine game in C#. Spin the reels and try to match the symbols to win credits.

## Table of Contents

- Slot Machine Game
- Table of Contents
- Motivation
- Installation
- Usage
- Technologies
- Acknowledgements
- License
- Contact

## Motivation

I created this project as a way to practice my C# skills and learn more about game development. I wanted to create a simple and fun game that simulates a slot machine. The game features a graphical user interface, sound effects, and random outcomes.

## Installation

To download, install, and run this project, you will need:

- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- Windows 10 or later

You can clone this project from GitHub using the following command:

`git clone https://github.com/your-username/slot-machine-game.git`

Alternatively, you can download the ZIP file from the GitHub repository and extract it to your desired location.

To open the project in Visual Studio, double-click on the `SlotMachine.sln` file in the root folder.

To run the project, press F5 or click on the Start button in Visual Studio.

## Usage

To play the game, follow these steps:

- Enter your cash deposit amount and press Enter. You will receive playing credits based on your deposit amount.
- Enter your wager amount and press Enter. You can wager up to 10 credits per spin.
- Press the Spin button or the Spacebar to spin the reels. You will hear a sound effect and see the reels spinning.
- Wait for the reels to stop. You will see the symbols on the reels and hear a sound effect indicating whether you won or lost.
- If you matched three symbols on a row or a column, you will win credits based on the symbol and the wager amount. The winning lines will be highlighted and the credits will be added to your balance.
- If you did not match any symbols, you will lose your wager amount and the credits will be deducted from your balance.
- You can continue to play until you run out of credits or decide to quit. To quit, press the Quit button or the Escape key.
- You will see a message showing your final balance and a farewell message.

Here are some screenshots of the game:

![Screenshot 1]
![Screenshot 2]
![Screenshot 3]

## Technologies

I used the following technologies, tools, and frameworks to create this project:

- C# as the programming language
- Visual Studio 2019 as the integrated development environment
- .NET Framework 4.7.2 as the software framework
- System.Random as the random number generator class

Some of the challenges or difficulties that I faced and how I overcame them are:

- Creating a grid of labels to display the symbols on the reels. I used a nested for loop to create and position the labels dynamically.
- Generating random symbols for each reel. I used an array of strings to store the symbols and a random number generator to select a random index from the array.
- Checking for winning combinations on the rows and columns. I used another nested for loop to compare the symbols on each row and column and a counter to keep track of the matching symbols.
- Playing sound effects for spinning, winning, and losing. I used the SoundPlayer class to load and play the sound files from the resources folder.
- Handling user input and events. I used the KeyPress and Click events to handle the keyboard and mouse input and the Timer and Tick events to handle the spinning animation.

## Acknowledgements

I would like to thank or credit the following sources, references, or inspirations that helped me with this project:

- [Microsoft Docs] for providing the documentation and tutorials for C#, Visual Studio, .NET Framework, and Windows Forms.
- [Rakete Mentoring] for providing the answers and solutions to various programming questions and problems.

## License

This project is licensed under the MIT License. See the [LICENSE] file for more details.

## Contact

If you want to connect with me or have any questions or feedback about this project, you can reach me at:

- Email: pajic.marko84@gmail.com
