# Instructions

## Run docker-compose.yaml

The file has instructions to up Elasticsearch and Kibana

to run, in the directory with contains the file docker-compose.yaml
$ docker-compose up

ports:
		ElasticSearch
		http://localhost:9200

		Kibana
		http://localhost:5601



Using in this project:
 * **Serilog.AspNetCore** The main package
   $ Install-Package Serilog.AspNetCore -Version 3.4.0

 * **Serilog.Sinks.ElasticSearch** It supports a variety of logging destinations, referred to as Sinks, 
   from standard console and files based sinks to logging services such as Datadog or ElasticSearch.
   $ Install-Package Serilog.Sinks.ElasticSearch -Version 8.4.1

 * **Serilog.Enrichers.Environment** Environment enrichers - Enrich logs with the machine or current user name
	 $ Install-Package Serilog.Enrichers.Environment -Version 2.1.3

