CPSC 481

RADBOX (HTPC for kids)

Authors: Daniel Lewis,
         Manorie Vachon,
         Zach Scott

        
This system provides children with an easy-to-use and intuitive interface on which they can seamlessly
watch movies or TV shows and/or look at pictures.

To run the application, either build / run from Visual Studio or run the included 'RadBox_start.exe'. If you 
are running from the executable, make sure the 'Assets' folder is in the same directory. After starting, the 
home page will appear with three button options. These options are:

- 'Movies/Shows' Button: Select this if you'd like to watch a movie or TV show. The pre-loaded movies are 
						 shown in the bottom scroll bar, with the currently selected one shown in the bigger 
						 square window right above that. The options of things to do on this page are listed 
						 below:
						 
						 -- Scroll side-to-side through the movies with the left and right arrow buttons, which 
						 will also change the currently selected movie (as the middle thumbnail of the three 
						 in the scroll bar). Clicking the other thumbnails in the scroller will work as well.
						 
						 -- There are categories by which the movies can be sorted. Clicking the ‘Categories’ 
						 icon in the top right will bring down a list of categories to choose from.  Selecting 
						 one will refine the list of movies available in the bottom scroll bar. To view all 
						 movies again, simply go back to categories and select ‘All’.
						 
						 -- Clicking anywhere on the currently selected movie (the larger thumbnail in the 
						 middle of the screen), including the green play button overlaid on it, will put the 
						 movie into full screen mode and start playing it.
						 
							--- In full screen mode, there is an adjustable volume bar in the bottom right corner,
							as well as a back button in the top left.  If the mouse is hovered over the playing 
							video, fast forward, rewind, and pause buttons appear. The fastforward and rewind
							buttons can be clicked or clicked and held to seek through the video. 
							Clicking anywhere else on the video screen will pause it and minimize to the 
							previous screen. The video can then be played again by starting it the same way as 
							before (clicking anywhere on the preview of it). Any number of videos can be paused
							and resumed, so your place is always saved. If you watch a video to completion, you
							will be automatically brought back to the previous screen, and the thumbnail will 
							be greyed out so you can tell which videos you have watched.
							
						 -- There are two toggle button on the middle left side of the page. When ‘Movies’ is 
						 active, the bottom bar will be populated with movies. When ‘TV Shows’ is active, 
						 the bottom bar will be populated with the TV Shows. Note: This is not fully implemented.
						 The bottom bar will always be populated with movies.
						 
						 -- The only difference from here is that when ‘TV Shows’ is selected, an ‘Episodes’ bar 
						 is displayed in the central right region. The bottom scroll bar contains each different 
						 show that is in the database, while the ‘Episodes’ bar displays all the episodes of the 
						 currently selected show. This feature is not fully implemented at this time, but the episodes 
						 selector will be shown if you toggle to TV mode. This is here to show the design choice; 
						 clicking on an episode will not change the currently selected video.
						 
						 -- All other functionality is the same as when ‘Movies’ is selected, in terms of 
						 scrolling, selecting a show, playing it (the controls in fullscreen mode are the same), 
						 selecting a category, and going back to the home page.
						 
						 -- Click the Home (house icon) in the upper left corner to return to the home page.

- 'Pictures' Button: Select this if you'd like to view pictures. The pictures are shown in the bottom scroll bar, 
					 with the currently selected one shown in the bigger square window right above that. By 
					 default, if the pictures have albums, the scroll bar is populated with pictures from the 
					 first album in the list, which is always 'All' on the first boot. On this page, you can:
					 
					 -- Scroll side-to-side through the pictures with the left and right arrow buttons, which will 
					 change the currently selected picture; clicking on one of the other two pictures shown along the 
					 bottom works as well.
					 
					 -- A scrolling album viewer can be found in the middle left of the screen. This is a list of 
					 all the albums in the database, starting from ‘most recently viewed’ at the top, and going to 
					 the ‘least recently viewed’. Clicking on any of these album pictures (each album has a picture 
					 as a sample of what is in the album and a name), will populate the bottom scrolling viewer 
					 with the pictures from that album.
					 
					 -- By clicking on the currently selected picture, the system enters full screen mode.
						
						--- Full screen mode displays the enlarged image, its title (above it), a back button 
						(the same as in the ‘Movies/TV Shows’ full screen section, in the upper left corner) and a 
						slideshow button appear. Full screen pictures are by default in slideshow mode. While in
						slideshow mode, the pictures will automatically progress without user input. If the 
						slideshow button in the top right corner is pressed, this toggles the slideshow mode 
						on/off. Left and right arrows beside the picture are also available to manually scroll 
						backwards or forwards through the images. Clicking the back button or anywhere on the 
						picture itself will return to the previous screen.
					 
					 -- Click the Home (house icon) in the upper left corner to return to the home page.

- Power Icon Button: Shuts down the system.


Picture References:
- Green TV: http://www.polyvore.com/cgi/img-thing?.out=jpg&size=l&tid=7197672
- Edited this camera: https://www.centrolutions.com/Images/CameraGreen.png

Movies References:
- WE DO NOT CLAIM TO OWN RIGHTS ANY OF THE VIDEOS INCLUDED IN THIS PROJECT. THEY ARE MERELY FOR DEMONSTRATIVE PURPOSES.
- All video material was taken from Youtube.com and Bollycine.net.



