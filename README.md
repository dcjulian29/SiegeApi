Siege API
=======

Siege is an http load testing and benchmark utility. It was designed to let web developers measure their code under duress, to see how it will stand up to load on the internet. Siege supports basic authentication, cookies, HTTP, HTTPS and FTP protocols. It lets its user hit a server with a configurable number of simulated clients. Those clients place the server "under siege."

You can find more information about that program at [https://www.joedog.org/siege-home/](https://www.joedog.org/siege-home/)

This project is about wrapping the command-line use of the siege program so that other automated tools can use the features of Siege to load-test websites via an API. It also gives me the perfect excuse to use .Net Core since Siege does not run (well) on Windows (via Cygwin)...

License
=======

While the Siege project itself is licensed via a GNU General Public License 3.0, this project does not include the Siege program or link to any parts of the Siege code. You will need to download it separately and install it. This project; however, is licensed under the Apache License as to provide as much flexibility to the use of it. See [LICENSE](LICENSE.md)

Contributing
=======

I welcome any contributions to this project to contribute code or squash a bug. Please familiarize yourself with [CONTRIBUTING](CONTRIBUTING.md)

