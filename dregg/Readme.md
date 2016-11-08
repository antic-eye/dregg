# Dregg #

The software "Dregg" (saxon vernacular for ["Trac"][trac]) is a small, quick
and dirty hack to get ticket data from an instance of ["Trac"][trac].

It queries a hardcoded trac instance for tickets to a given milestone that
contain the string "#RN" in comments or changesets to be able to automate the
release note generation.

After the query an ANSI CSV file is generated and opened with the default
application.

It is not really generic but might be useful as a base to start with C#,
Trac and the [XMLRPC Plugin][xmlrpc] using [JSON RPC][jsonrpc] as technology.

[trac]:https://trac.edgewall.org/ "Trac Bugtracker"
[xmlrpc]:https://trac-hacks.org/wiki/XmlRpcPlugin "Trac XML-RPC Plugin"
[jsonrpc]:https://en.wikipedia.org/wiki/JSON-RPC "JSON-RPC is a remote procedure call protocol encoded in JSON."
