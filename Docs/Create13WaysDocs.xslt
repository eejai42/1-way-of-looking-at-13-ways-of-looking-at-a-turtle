<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:param name="output-filename" select="'output.txt'" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*">
        <FileSet>
            <FileSetFiles>
                <FileSetFile>
                    <RelativePath>
                        <xsl:text>Index.html</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve"><html>
    <head>
        <title>One way of Looking at 13 Ways of Looking At A Turtle</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous" />
        <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/angular.js/1.0.3/angular.min.js"></script>
    </head>
    <body style="padding: 1em; font-size: 0.9em;">
        <h1>One Way of Looking at</h1>
        <h2>13 ways of looking at a turtle</h2>
        <div>
            <p>
                This fork of <a href="https://github.com/swlaschin/13-ways-of-looking-at-a-turtle">13 Ways of looking at a Turtl</a>.  This
                Fantastic <a href="http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/">Article/Blog Post</a>
                inspired me to use it has the basis for demonstrating the power of having a
                Single Source of Truth (SSoT) when developing software.
            </p>

            
        </div>
    </body>
</html>
</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
