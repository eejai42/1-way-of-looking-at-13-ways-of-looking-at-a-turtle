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

            <p>
                The purpose of the original article, was to demonstrate 13 different ways
                to solve the same problem.  The reason this is such a great starting
                place to domonstrate the SSoT toolset, is that "the code" is what it is.
                In other words, the decision of what the code should be is already decided.
            </p>
            <p>
                The question asked by this fork of the repo is, what's the best way to 
                Create/Manage that code.
            </p>
            <h3>Commands</h3>
            <p>
                The "basic" Turtle is able to perform these commands.
            </p>
            <ul>
                <xsl:for-each select="//TurtleCommand[Version = 1]">
                <b><xsl:value-of select="Name"/></b><br />
                <div style="font-size: 0.8em;"><xsl:value-of select="Description"/></div>
                </xsl:for-each>
            </ul>

            <p>
                Some of the tools developed after the first 13 ways, include the following 
                additional commands.
            </p>
            <ul>
                <xsl:for-each select="//TurtleCommand[Version > 1]">
                <b><xsl:value-of select="Name"/></b><br />
                <div style="font-size: 0.8em;"><xsl:value-of select="Description"/></div>
                </xsl:for-each>
            </ul>

            <h3>Predefined Scripts</h3>
            <p>
                The original article uses these simple commands to demonstrate 13 ways
                of looking at a turtlle.  In each example, he demonstrates the approach by
                drawing:
            </p>
            <ol>
                <li>A Triangle</li>
                <li>Three Lines</li>
                <li>A Polygon</li>
            </ol>
            <p>
                In Designing the single source of truth for this project, I call the first
                two examples "PredefinedScript".  This is a script which only uses the basic
                Turtle Commands to complete a certain sequence of steps (a "PredefinedScriptStep").
            </p>
            <p>
                At this point in time, the SSoT for this project includes <xsl:value-of select="count(//PredefinedScript)"/> Predefined
                Scripts.  They are:
            </p>
            <ul>
                <xsl:for-each select="//PredefinedScripts/PredefinedScript">
                <li>
                    <h5>Drawing a <xsl:value-of select="Name"/></h5>
                    <ol>
                        <xsl:for-each select="//PredefinedScriptStep[PredefinedScript = current()/Name]">
                            <li><b><xsl:value-of select="Command" /></b> <xsl:value-of select="Argument" /></li>
                        </xsl:for-each>
                    </ol>
                </li>
                </xsl:for-each>
           </ul>
           <h3>The Ways</h3>
            <p>
                Let's start by looking at "the ways".
            </p>
            <xsl:for-each select="//WayOfLookingAtATurtle">
                <div style="font-size: 0.8em; margin-top: 1em;">
                    <h5><xsl:value-of select="Name"/></h5>
                    <div style="whitespace: pre-wrap">
                        <xsl:value-of select="Description"/>
                    </div>
                </div>
            </xsl:for-each>
        </div>
    </body>
</html>
</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
