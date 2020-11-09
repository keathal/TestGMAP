# TestGMAP
Win Forms/WCF/Entity Framework project implementing work with GMAP .Net

To run the project create database using script.sql, refresh Entity Model, recompile WcfService and refresh ServiceReference link.

Implemented functional:
1. Map View
2. Loading positions, colors and desciptions from database
3. Parsing loaded data to markers on map
4. Drawing a polygon by coordinates
5. Drag & Drop markers with saving new position to database
6. Event on moving marker inside polygon
7. Adding random marker (with saving to database)
8. Changing marker color to random one
