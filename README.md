# C-simple-web-server
PREFACE
The example code below is a C# implementation of a simple web server. Copy the code to Visual Studio. Note: To run (and test) the web server, it is assumed that there is a "index.html" file (containing something) in the root of the project (that is, there must be a file called index.html in the project folder. Otherwise the program will crash.) 

Examine the code to see how it works. 

Notice how line 41contains a sleep command. If you try to access your web server / web page on the web browser, and immediately try to refresh the page, you will see that there is about a 5 second delay before the page loads again. 

BACKGROUND
Different servers are ubiquitous in computing. Usually when we talk about servers we mean specifically web servers... but this in fact could not be further from the truth. Operating systems frequently contain components which act as servers. For example, certain OS services are called "servers." 

However, all servers basically have the same working principle. They wait for client to request for some resource. At the time of the request they do their best to fetch the resource and return it to the client. 

Sometimes there is only one client for a server. Often, there are several clients. If there are more than one clients, we must take some multiprocessing and security considerations into account! One request may not crash the others. At the same time, we should aim to serve all clients equally efficiently. 

THE TASK 
Because of line 41 in the code we cannot have two back-to-back requests to this web server. (This limitation is at this point completely artificial, but it is there to simulate a delay in fetching a resource). Therefore, we have to do something to allow the server to be accessed simultaneously - after all, you would not like to see any web site having random five second delays. 

Add threading to the code. That is, change the code so that within the while loop the critical bits (i.e. the response and the sleeping) are executed inside their own thread. You can find examples and documentation on threading here
