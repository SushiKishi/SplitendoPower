# Livesplit.SplitendoPower

Note: This project is a work in progress and not yet available, but I am nothing if not ambitious in short spurts like this.
## Now you're splitting with power!
Are you a speedrunner who *[gasps]* uses notes, to the shock and awe of all of your friends? Do you wish those notes could be something more than just plain text? Would it help to be able to pull up a step route for your Final Fantasy IV run, or see an in-game screenshot of your all-Japanese equipment menu in Live A Live, or see which pixel you need to stand on for a cliff skip in Earthbound?

Then it's time to reach for power...Splitendo Power!

## What's Splitendo Power?
There's two parts to Splitendo Power. The first is very simple -- you'll add the component to your LiveSplit layout, and it will get the information needed to keep you on the right page of your notes. If you don't want to be visible on the layout, there is an option for it to be hidden; as long as it's added to your layout, it'll run whether or not you can see it.

Then the main note-reading application will let you pick which issue of Splitendo Power you want to use and will flip through it page-by-page as you split through your run. These "issues" of the magazine are your speedrunning notes, and the idea is for you to be able to use a wide variety of formats:"
* PDF - One page per split should be easy to implement; multiple pages per split will be tougher but I'll work on it if there's interest.
* * Images - A series of images (named 01.png 02.png etc, or named after splits).
* Plain Text - SplitNotes style, you can just use a plain text file divided by .split or any delimiter you choose.
* A Webpage with Anchor Tags -- domain.ext/#1 #2 #3, etc.
* A list of URLS -- A fairly niche usecase but may be helpful in certain situations.

It includes a way for you to preview your notes before starting the run, to make sure they're working as intended and in order. You can also disable automatic page-flipping to either check the page order for yourself, or resolve an issue that comes up mid-run unexpectedly without losing your page.

## How to install

TL;DR version: Add component to Livesplit, edit its settings, SAVE YOUR LAYOUT (or you will lose your settings), run the app.

Step-by-Step:
1. Go to the Releases page; download the latest release
2. Put the file in the Livesplit Component folder inside your LiveSplit/Component folder
3. Put the SplitendoPower folder anywhere you can access it quickly; this is how you'll read your notes.
4. Open Livesplit, edit your layout, and add the new Splitendo Power component (under 'Other') to your layout.
5. Edit the settings of the Splitendo Power component. Make sure you set where your SplitendoPower folder is. Optionally turn the Power Indicator on or off.
6. SAVE YOUR LAYOUT. If you do not save your layout, you will lose your settings!
7. Run Splitendo Power.exe from your SplitendoPower folder.

## How to set up a Issue of Splitendo Power

1. Open the "issues" folder
2. Create a new folder for run; one folder per set of notes.
3. Use the Wiki to determine how to name your files, then add them into the folder you created.
4. Open Splitendo Power; you should see your new issue listed on the main page
5. Open your issue; and configure it as needed. Configuration help available on the Wiki.

## Testing/Manual Scrolling
Yeah, yeah, I know, the point is that this is supposed to be AUTOMATED. And it is! But if you want to test that your notes are in order, Start Reading then use the pause button, and you can flip through page-by-page.


## FAQs
Coming soon.

## Other Information

### How does it work?

The livesplit component creates a few files in the Splitendo Power directory every time you change splits. One has your current split number (starting at 0); one has the current split name, one has the current split name with no spaces.

Splitendo Power.exe is just PHPDeskop running PHP and JavaScript code that I created in an instance of Google Chrome. You can also host this on an XAMPP or similar web instance on your own and use whichever browser you want, but PHPDesktop is the easiest way to distribute web-based applications.

All of the code for both the Livesplit Component and the backend of Splitendo Power are open source can be read here.

### XAMPP or Local Webserver setup

Coming soon.

### Support

Xwitter/Twitch/CoHost/YouTube -- SushiKishi. Tagging me on social media or popping into chat and politely asking a question is the best way to get in touch with me! Discord DMs from people I don't know will probably be ignored.