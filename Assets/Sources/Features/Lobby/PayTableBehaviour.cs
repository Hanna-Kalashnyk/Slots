using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
//using UnityEditor;

public class PayTableBehaviour : MonoBehaviour, IStoreListener
    {

        [SerializeField]
	public Text _Balance;

    [SerializeField]
    private int lastBalance;



    [SerializeField]
    public static int dublicateBalance;

    // Use this for initialization
    void Start () {		
		_Balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";
        dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);


    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void payTwoDollar(){
        dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
        lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 3500000;
		PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
		_Balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";
                //EditorUtility.DisplayDialog ("", "Your payment succeeded", "OK", "");			
    }

	public void payFiveDollar(){

        dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);

        int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 13500000;
		PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
		_Balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";
        print("five dollars");
		//EditorUtility.DisplayDialog ("", "Your payment succeeded", "OK", "");
	}


    public void payTenDollar()
    {
        dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
        int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 40000000;
        PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
        _Balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";
        //EditorUtility.DisplayDialog ("", "Your payment succeeded", "OK", "");
    }


    public void payFifteenDollar()
    {
        dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
        int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 80000000;
        PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
        _Balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";
        //EditorUtility.DisplayDialog ("", "Your payment succeeded", "OK", "");
    }


    public void payThirtyDollar(){
        dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
        int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 225000000;
		PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
		_Balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";
		//EditorUtility.DisplayDialog ("", "Your payment succeeded", "OK", "");
	}


    public void payFiftyDollar()
    {
        dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
        int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 810000000;
        PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
        _Balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";
        //EditorUtility.DisplayDialog ("", "Your payment succeeded", "OK", "");
    }


    public void payHundredDollar(){
        dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
        int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 360000000;
		PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
		_Balance.text = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + "";
		//EditorUtility.DisplayDialog ("", "Your payment succeeded", "OK", "");
	}

    
/////	<------------PAYMENT----------------->
	private static IStoreController m_StoreController;          // The Unity Purchasing system.
	private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

	// Product identifiers for all products capable of being purchased: 
	// "convenience" general identifiers for use with Purchasing, and their store-specific identifier 
	// counterparts for use with and outside of Unity Purchasing. Define store-specific identifiers 
	// also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

	// General product identifiers for the consumable, non-consumable, and subscription products.
	// Use these handles in the code to reference which product to purchase. Also use these values 
	// when defining the Product Identifiers on the store. Except, for illustration purposes, the 
	// kProductIDSubscription - it has custom Apple and Google identifiers. We declare their store-
	// specific mapping to Unity Purchasing's AddProduct, below.
	public static string kProductIDConsumable =    "consumable";   
	public static string kProductIDNonConsumable = "nonconsumable";
	public static string kProductIDSubscription =  "subscription"; 

	// Apple App Store-specific product identifier for the subscription product.
	private static string kProductNameAppleSubscription =  "com.wArMax.subscription.new";

	// Google Play Store-specific product identifier subscription product.
	private static string kProductNameGooglePlaySubscription =  "com.wArMax.subscription.original"; 

	public void InitializePurchasing() 
	{
		// If we have already connected to Purchasing ...
		if (IsInitialized())
		{
			// ... we are done here.
			return;
		}

		// Create a builder, first passing in a suite of Unity provided stores.
		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

		// Add a product to sell / restore by way of its identifier, associating the general identifier
		// with its store-specific identifiers.
		builder.AddProduct(kProductIDConsumable, ProductType.Consumable);

		// Continue adding the non-consumable product.
		builder.AddProduct(kProductIDNonConsumable, ProductType.NonConsumable);
		// And finish adding the subscription product. Notice this uses store-specific IDs, illustrating
		// if the Product ID was configured differently between Apple and Google stores. Also note that
		// one uses the general kProductIDSubscription handle inside the game - the store-specific IDs 
		// must only be referenced here. 
		builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs(){
			{ kProductNameAppleSubscription, AppleAppStore.Name },
			{ kProductNameGooglePlaySubscription, GooglePlay.Name},
		});

		// Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
		// and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
		UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized()
	{
		// Only say we are initialized if both the Purchasing references are set.
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}


	public void BuyConsumable()
	{
		// Buy the consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(kProductIDConsumable);
	}


	public void BuyNonConsumable()
	{
		// Buy the non-consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(kProductIDNonConsumable);
	}


	public void BuySubscription()
	{
		// Buy the subscription product using its the general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		// Notice how we use the general product identifier in spite of this ID being mapped to
		// custom store-specific identifiers above.
		BuyProductID(kProductIDSubscription);
	}


	void BuyProductID(string productId)
	{
		// If Purchasing has been initialized ...
		if (IsInitialized())
		{
			// ... look up the Product reference with the general product identifier and the Purchasing 
			// system's products collection.
			Product product = m_StoreController.products.WithID(productId);

			// If the look up found a product for this device's store and that product is ready to be sold ... 
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
				// asynchronously.
				m_StoreController.InitiatePurchase(product);
			}
			// Otherwise ...
			else
			{
				// ... report the product look-up failure situation  
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		}
		// Otherwise ...
		else
		{
			// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
			// retrying initiailization.
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}


	// Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
	// Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
	public void RestorePurchases()
	{
		// If Purchasing has not yet been set up ...
		if (!IsInitialized())
		{
			// ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}

		// If we are running on an Apple device ... 
		if (Application.platform == RuntimePlatform.IPhonePlayer || 
			Application.platform == RuntimePlatform.OSXPlayer)
		{
			// ... begin restoring purchases
			Debug.Log("RestorePurchases started ...");

			// Fetch the Apple store-specific subsystem.
			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			// Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
			// the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
			apple.RestoreTransactions((result) => {
				// The first phase of restoration. If no more responses are received on ProcessPurchase then 
				// no purchases are available to be restored.
				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		}
		// Otherwise ...
		else
		{
			// We are not running on an Apple device. No work is necessary to restore purchases.
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}


	//  
	// --- IStoreListener
	//

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		// Purchasing has succeeded initializing. Collect our Purchasing references.
		Debug.Log("OnInitialized: PASS");

		// Overall Purchasing system, configured with products for this application.
		m_StoreController = controller;
		// Store specific subsystem, for accessing device-specific store features.
		m_StoreExtensionProvider = extensions;
	}


	public void OnInitializeFailed(InitializationFailureReason error)
	{
		// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}


	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
	{
              // A consumable product has been purchased by this user.
        if (args.purchasedProduct.definition.id.Equals("majestic.two"))
		{
            dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
            print ("two dollar");
            //Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 3500000;
            //Rect popupMenuRect = new Rect( 500 , 400 , 200 , 200 ) ;
            //EditorUtility.DisplayPopupMenu (popupMenuRect, "You've made a purchase for two dollars", null);            
            PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
            Debug.Log(string.Format("ProcessPurchase: SUCCESS. Unrecognized product: '", args.purchasedProduct.definition.id));

			//Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			// The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
			//EditorUtility.DisplayDialog ("", "Your payment was accepted", "", "Thank you");
		}
		else if (args.purchasedProduct.definition.id.Equals("majestic.five"))
		{
            dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
            print ("five dollar");
			//Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			// The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 13500000;
			//Rect popupMenuRect = new Rect( 500 , 400 , 200 , 200 ) ;
			//EditorUtility.DisplayPopupMenu (popupMenuRect, "You've made a purchase for five dollars", null);			
			PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
			Debug.Log(string.Format("ProcessPurchase: SUCCESS. Unrecognized product: '", args.purchasedProduct.definition.id));
		}

        else if (args.purchasedProduct.definition.id.Equals("majestic.ten"))
        {
            dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
            print("ten dollars");
            //Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 40000000;
            //Rect popupMenuRect = new Rect( 500 , 400 , 200 , 200 ) ;
            //EditorUtility.DisplayPopupMenu (popupMenuRect, "You've made a purchase for ten dollars", null);			
            PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
            Debug.Log(string.Format("ProcessPurchase: SUCCESS. Unrecognized product: '", args.purchasedProduct.definition.id));
        }

        else if (args.purchasedProduct.definition.id.Equals("majestic.fifteen"))
        {
            dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
            print("fifteen dollars");
            //Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 80000000;
            //Rect popupMenuRect = new Rect( 500 , 400 , 200 , 200 ) ;
            //EditorUtility.DisplayPopupMenu (popupMenuRect, "You've made a purchase for fifteen dollars", null);			
            PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
            Debug.Log(string.Format("ProcessPurchase: SUCCESS. Unrecognized product: '", args.purchasedProduct.definition.id));
        }
        else if (args.purchasedProduct.definition.id.Equals("majestic.thirty"))
		{
            dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
            print ("thirty dollars");
			//Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			// The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 225000000;
			//Rect popupMenuRect = new Rect( 500 , 400 , 200 , 200 ) ;
			//EditorUtility.DisplayPopupMenu (popupMenuRect, "You've made a purchase for thirty dollars", null);			

			PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
			Debug.Log(string.Format("ProcessPurchase: SUCCESS. Unrecognized product: '", args.purchasedProduct.definition.id));
		}

        else if (args.purchasedProduct.definition.id.Equals("majestic.fifty"))
        {
            dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
            print("fifty dollars");
            //Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 810000000;
            //Rect popupMenuRect = new Rect( 500 , 400 , 200 , 200 ) ;
            //EditorUtility.DisplayPopupMenu (popupMenuRect, "You've made a purchase for fifty dollars", null);			

            PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
            Debug.Log(string.Format("ProcessPurchase: SUCCESS. Unrecognized product: '", args.purchasedProduct.definition.id));
        }
        else if (args.purchasedProduct.definition.id.Equals("majestic.hundred"))
		{
            dublicateBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE);
            print ("hundred dollar");
			//Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			// The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
			int lastBalance = PlayerPrefs.GetInt(Constants.PLAYER_BALANCE) + 360000000;
			PlayerPrefs.SetInt(Constants.PLAYER_BALANCE, lastBalance);
			//Rect popupMenuRect = new Rect( 500 , 400 , 200 , 200 ) ;
			//EditorUtility.DisplayPopupMenu (popupMenuRect, "You've made a purchase for hundred dollar", null);			

			Debug.Log(string.Format("ProcessPurchase: SUCCESS. Unrecognized product: '", args.purchasedProduct.definition.id));
		}
		// Or ... an unknown product has been purchased by this user. Fill in additional products here....
		else 
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '", args.purchasedProduct.definition.id));
		}

		// Return a flag indicating whether this product has completely been received, or if the application needs 
		// to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
		// saving purchased products to the cloud, and when that save is delayed. 
		return PurchaseProcessingResult.Complete;
	}


	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		//EditorUtility.DisplayDialog ("", "Your payment process failed", "", "");			
		
		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
		// this reason with the user to guide their troubleshooting actions.
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}
    
}

