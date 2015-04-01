# Xamarin Tag Manager Android
Step by step guide to integrate google tag mamager in Xamarin Android

This sample project demonstrates how to integrate Google tag manager in Xamarin.Android.

Installation:

In the Droid project, add Google Play Services SDK, the google tag manager will reference that SDK.

*I will demonstrate in this guide how to fire an event from tag manager to Google Analytics.

Configuration:

1) Create a Google Analytics account, please make sure you select a mobile account 
(Under New Property - you'll have to select mobile/Web).

2) Create a Google Tag Manager account - create a container, then create a tag of type Google Analytics - universal analytics.
   a) Put your analytics account id in the Tracking ID (should be in the form "UA-XXXXXX-X").
   b) Create a macro for screen name (you can view in the screenshots 'TagManagerMacro.jpeg')
   c) The Rule Track Type should be App View.
   d) In the more settings --> basic configuration --> screen name - add the macro we defined in step b.
   e) In Firing rules - make sure your rule is set for always.
   
   
Code (at last!):

In your Activity, call to 
    
    var tagmanager = TagManagerClass.GetInstance(this);
    
     var pendingResult = _tagmanager.LoadContainerPreferNonDefault("GTM-XXXXXX",
                Resource.Raw.gtm_analytics);

    pendingResult.SetResultCallback(new TagMnagerResultCallback(), 2, TimeUnit.Seconds);
    
After the callback as returned, you can fire events like this:

    _tagmanager.DataLayer.PushEvent("openScreen", DataLayer.MapOf("screenName", "testScreen"));

Lastly, this guide was followed by the guidelines instructed here: https://developers.google.com/tag-manager/android/v4/
