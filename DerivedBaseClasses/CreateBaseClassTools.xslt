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
            <xsl:for-each select="//WayOfLookingAtATurtle">
                <FileSetFile>
                    <RelativePath>
                        <xsl:value-of select="WayNumber" /><xsl:text>/CreateBaseClass.xslt</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">&lt;?xml version="1.0" encoding="utf-8"?>
&lt;xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    &lt;xsl:output method="xml" indent="yes"/>

    &lt;xsl:param name="output-filename" select="'output.txt'" />

    &lt;xsl:template match="@* | node()">
        &lt;xsl:copy>
            &lt;xsl:apply-templates select="@* | node()"/>
        &lt;/xsl:copy>
    &lt;/xsl:template>

    &lt;xsl:template match="/*">
        &lt;FileSet>
            &lt;FileSetFiles>
                &lt;FileSetFile>
                    &lt;RelativePath>
                        &lt;xsl:text>../<xsl:value-of select="WayNumber" />Base.fsx&lt;/xsl:text>
                    &lt;/RelativePath>
                    &lt;xsl:element name="FileContents" xml:space="preserve">(* ======================================
01-OOTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way #1: Simple OO -- a class with mutable state

In this design, a simple OO class represents the turtle,
and the client talks to the turtle directly.

====================================== *)

#load "../Common.fsx"

open System
open Common

// ======================================
// OO Turtle
// ======================================

// see code in this file
#load "../OOTurtleLib.fsx"

// ======================================
// OO Turtle Client
// ======================================

module <xsl:value-of select="WayNumber" />Base = 
    open OOTurtleLib

    /// Function to log a message
    let log message =
        printfn "%s" message 

    &lt;xsl:for-each select="//PredifinedScript">
    &lt;xsl:variable name="pds-name" select="Name" />
    let draw&lt;xsl:value-of select="$pds-name" />() = 
        printfn "PRINTING &lt;xsl:value-of select="$pds-name" />!"
        let turtle = Turtle(log)
        &lt;xsl:for-each select="//PredifinedScriptStep[normalize-space(PredefinedScript) = $pds-name]">&lt;xsl:if test="normalize-space(Description) != ''">
        // &lt;xsl:value-of select="Description" />&lt;/xsl:if>&lt;xsl:text>
        turtle.&lt;/xsl:text>&lt;xsl:value-of select="Command" /> &lt;xsl:value-of select="Argument" />&lt;xsl:choose>
            &lt;xsl:when test="ArgumentType = 'Degrees'">.0&amp;lt;Degrees>&lt;/xsl:when>
            &lt;xsl:when test="ArgumentType = 'Distance'">.0&lt;/xsl:when>
            &lt;xsl:when test="normalize-space(ArgumentType) = ''">()&lt;/xsl:when>
        &lt;/xsl:choose>&lt;/xsl:for-each>
    &lt;/xsl:for-each>
    

&lt;/xsl:element>
                &lt;/FileSetFile>
            &lt;/FileSetFiles>
        &lt;/FileSet>
    &lt;/xsl:template>
&lt;/xsl:stylesheet>

</xsl:element>
                </FileSetFile>
                </xsl:for-each>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
