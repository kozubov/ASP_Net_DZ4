# ASP_Net_DZ4

The task to implement the library in ASP.NET MVC<br/>

Main classes:<br/>
Publisher<br/>
Name: string<br/>

Author<br/>
Name: string<br/>
DateOfBirth: Date<br/>
DateOfDeath: Date?<br/>

Book<br/>
Id: int<br/>
Name: string<br/>
Publisher: Publisher<br/>
Authors: IEnumerable <Author><br/>
PublishDate: Date<br/>
PageCount: int<br/>
ISBN: string<br/>

Implement controllers for each of the classes, for basic actions - Creating, Receiving, Modifying, Deleting.<br/>

If an author or publisher is deleted, they should be missing from books using this data, for example. the author is deleted,
the book where it appears, the deleted author disappears from the list of authors.<br/>

Generate tables with helpers
