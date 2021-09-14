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
   - Save/Save as (menu items): save the edited image

   <!-- ![File Menu](https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/file_menu.png) -->
   <p align="center"> <img src="https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/file_menu.png" height="400"/> </p>
   
2. Customize menu
   - New color theme (menu item): choose two colors from a color dialog box and create a new color theme for the application (i.e., the background colors of the window)
   - Custom color themes (menu item): select an already existing color theme (four such themes are available)

   <!-- ![Customize Menu](https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/customize_menu.png) -->
   <p align="center"> <img src="https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/customize_menu.png" height="400"/> </p>
   

3. Edit menu
   - Draw points (menu item): start drawing points of a chosen color
   - Draw circles (menu item): start drawing circles of a chosen color
   - Draw multicolored circles (menu item): start drawing circles. The color of each circle is randomly selected
   - Stop drawing (menu item)
   - For every selected menu option a new window opens in order for the user to choose the size of the points/circles and to press the ```D``` key to start drawing and the ```Enter``` key to stop drawing (or to select the stop drawing option from the edit menu).
   
   <p align="center"> <img src="https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/edit_menu.png" height="400"/> </p>


4. Filter menu (add a filter to the image)
   - Default (return to default image if filter has already been added)
   - Black and white
   - Sepia
   - Negative
   
   <p align="center"> <img src="https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/filter_menu.png" height="400"/> </p>


5. Add menu
   - Photo (menu item): add a photo to the current image. After selecting the photo to be added and its size, the user has to ```right click``` anywhere on the application's window and to press the ```Add photo here``` in order to add the photo

   <p align="center"> <img src="https://github.com/EmanuelPutura/PhotoEditor/blob/main/img/add_menu.png" height="400"/> </p>
