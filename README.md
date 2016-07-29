# Solr Integration 

`SyntacticDocs` uses **solr** as the main search engine 
with a tweaked configuration that has been optimalised 
for technical documents. 

## Getting started with solr

To start download [solr](http://archive.apache.org/dist/lucene/solr/6.1.0/) 
and extract the files into your prefered location 
In this example we will use this location `/WorkSpace/solr-6.1.0`

**solr** uses java so you will need to have the 
[java run time](https://java.com/en/download/) to be installed.

To verify if java run time exist in your machine simply run the command: 

> `java -version `

You should see the java run time version printed out.

If you already have java start solr using the command bellow:

> `/WorkSpace/solr-6.1.0/bin/solr start`

If everything is fine it will run within **30 seconds**.

## Create the SyntacticDocs core

We will have to create the **core** in where the configuration 
and indexed data will be stored within solr, 
to do that we simply run the command:

> `/WorkSpace/solr-6.1.0/bin/solr create -c "SyntacticDocs"`

At this point we create a core with **the basic and default** configuartion, 
we will need to overwrite it with our configuation to do that 
[download our config files](https://github.com/benhallouk/syntactic-docs/archive/solr_config.zip)

Before we apply this configuration we need to stop the solr:

> `/WorkSpace/solr-6.1.0/bin/solr stop`

And then past the **unziped** files to the conf folder `/WorkSpace/solr-6.1.0/server/solr/SyntacticDocs/conf` 

## Postgresql import

The `SyntacticDocs` uses [Postgresql](https://www.postgresql.org/download/) 
as its main databse and so solr import the data from

To import the data ensure that you have installed 
[Postgresql](https://www.postgresql.org/download/) and that you run the 
`SyntacticDocs` to seed the data, if that's the case then navigate to the solr console in this path: 
[http://localhost:8983/solr/#/SyntacticDocs/dataimport//dataimport](http://localhost:8983/solr/#/SyntacticDocs/dataimport//dataimport)
and click the excute button 

if everything went as expected you should see some data coming back from the 
[search](http://localhost:8983/solr/SyntacticDocs/select?indent=on&q=*:*&wt=json)

**Happy Searching**.