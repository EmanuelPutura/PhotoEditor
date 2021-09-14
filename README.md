# PhotoEditor
 PhotoEditor is a photo editing application, written in C#. It provides filtering, drawing, merging and a few others options for editing your photos.
 
  <!-- ![Startup](https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/startup.png) -->
  <p align="center"> <img src="https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/startup.png" height="400"/> </p>


## Setup
 1. Clone the repo:
    ```sh
    $ git clone https://github.com/EmanuelPutura/PhotoEditor
    ```
 2. From the project's location:
    ```sh
    $ cd ./PhotoEditor/bin/Release
    $ PhotoEditor.exe
    ```


## Features
All the available features can be accessed from the menu bar.
1. File menu
   - New (menu item): start a new editing session
   - Open (menu item): select an already existing image to edit it
   - Save/Save as (menu items): save the image

   <!-- ![File Menu](https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/file_menu.png) -->
   <p align="center"> <img src="https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/file_menu.png" height="400"/> </p>
   
2. Customize menu
   - New color theme (menu item): choose two colors from a color dialog box and create a new color theme for the application (i.e., the background colors of the window)
   - Custom color themes (menu item): select an already existing color theme (four such themes are available)

   <!-- ![Customize Menu](https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/customize_menu.png) -->
   <p align="center"> <img src="https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/customize_menu.png" height="400"/> </p>
   

3. Edit menu
   For every selected menu option you have to press the ```D``` key to start drawing and the ```Enter``` key to stop drawing (or to select the stop drawing option from the edit menu).
   - Draw points (menu item): start drawing points of a chosen color
   - Draw circles (menu item): start drawing circles of a chosen color
   - Draw multicolored circles (menu item): start drawing circles. The color of each circle is randomly selected
   - Stop drawing (menu item)
   
   <p align="center"> <img src="https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/edit_menu.png" height="400"/> </p>
