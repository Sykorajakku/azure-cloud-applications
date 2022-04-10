# Explanation

All deployed source codes are available in the directory (some hardcoded secrets removed).
Screenshot from Azure portal / finished tutorials checkpoints provided below, also with some explanation!

# Lab 1 - App Deployment

Directory `lab-01-app` contains last version of application (after keyvault lab).

![lab01-01](lab-01-app/lab01_01.png)

![lab01-02](lab-01-app/lab01_02.png)


# Lab 2 - AzureSQL and WebJobs

Here I modified my WebJob logic -- it's not sending emails, only writes out to console.
Code in directory.

![lab02-01](lab-02-app/../lab-02-azure-sql/Screenshot%202022-04-08%20at%2023.34.02.png)
![lab02-02](lab-02-azure-sql/Screenshot%202022-04-08%20at%2023.34.06.png)
![lab02-04](lab-02-azure-sql/Screenshot%202022-04-08%20at%2023.38.10.png)
![lab02-03](lab-02-azure-sql/Screenshot%202022-04-08%20at%2023.37.57.png)


# Lab 3 - Blob Storage and Configurations

![lab03-01](lab-03-blob-storage/app-configuration-strings.png)
![lab03-03](lab-03-blob-storage/container-app-access-roles.png)
![lab02-04](lab-03-blob-storage/container-blobs.png)
![lab03-02](lab-03-blob-storage/app-screenshot.png)

# Lab 4 - Cosmos DB

Following the guide, I created items (all steps until Step 6):

![lab04-03](lab-04-cosmos-dob/../lab-04-cosmos-db/cosmos-app-add-items.png)

Looking at my Cosmos DB instance:

![lab04-07](lab-04-cosmos-db/cosmos-azure-add-items-query.png)

Step 7 running query:

![lab04-01](lab-04-cosmos-db/cosmos-app-add-items-query.png)

Replacing an item (console output):

![lab04-05](lab-04-cosmos-db/cosmos-app-replace-item.png)

Deleting an item (console output):

![lab04-06](lab-04-cosmos-db/cosmos-app-delete-item.png)

# Lab 5 - App Insights

Configuring Application Insights from Visual Studio 2022:

![lab05-01](lab-05-app-insights/Screenshot%202022-04-02%20at%2016.25.21.png)
![lab05-02](lab-05-app-insights/Screenshot%202022-04-02%20at%2016.25.31.png)
![lab05-03](lab-05-app-insights/Screenshot%202022-04-02%20at%2017.52.54.png)

Exploring freshly configured Application Insights:

![lab05-04](lab-05-app-insights/Screenshot%202022-04-02%20at%2018.24.30.png)

# Lab 6 - Managed Identity and KeyVault

## Managed Identity

I extended application from the first lab, `lab-01-app` directory contains deployed application using Azure.Identity!

![lab-06-02](lab-06-identity-and-keyvault/Screenshot%202022-04-10%20at%2021.05.45.png)
![lab-06-03](lab-06-identity-and-keyvault/Screenshot%202022-04-10%20at%2021.06.45%201.png)

## KeyVault

Testing Azure Identity on console app deployed as WebJob, setting Application Service access rights: 

![lab-06-01](lab-06-identity-and-keyvault/Screenshot%202022-04-02%20at%2020.05.33.png)

KeyVault data:

![lab-06-02](lab-06-identity-and-keyvault/Screenshot%202022-04-10%20at%2021.14.37.png)

Output from console app (Console app code in repo)

![lab-06-03](lab-06-identity-and-keyvault/Screenshot%202022-04-10%20at%2021.12.12.png)

Testing access to KeyVault secret from WebApp using `configuration[]`:

![lab-06-04](lab-06-identity-and-keyvault/Screenshot%202022-04-10%20at%2021.16.42.png)

Secret is printed -- only for quick demonstration purposes ;)

![lab01-02](lab-01-app/lab01_02.png)


# Lab 7 - Serverless

## Event Hub

Request metrics:

![lab-07-01](lab-07-serverless/event-hub/requests_metrics.png))

## Logic Apps

My configuration for the Twitter 'hook':

![lab-07-02](lab-07-serverless/logic-apps/configuration.png)

I got an email!

![lab-07-03](lab-07-serverless/logic-apps/Email.png)

Reviewing result:

![lab-07-04](lab-07-serverless/logic-apps/Run.png)

## Zodiac

Running application locally:

![lab-07-05](lab-07-serverless/zodiac/zodiac-local.png)

Testing the function in Azure:

![lab-07-06](lab-07-serverless/zodiac/zodiac-azure.png)

# Lab 8 - Cognitive Services

## Image Analysis

This image (TUM Munich, Fakultat fur Informatik, Rechnerhalle):

![lab-08-01](lab-08-cognitive-services/vision/01_ImageObjectsAnalysis/bin/Debug/IMG_0379.jpg)

Service log:

![lab-08-02](lab-08-cognitive-services/vision/01_ImageObjectsAnalysis/Screenshot%202022-04-06%20at%2022.46.33.png)


Debug output:

![lab-08-03](lab-08-cognitive-services/vision/01_ImageObjectsAnalysis/Screenshot%202022-04-06%20at%2022.49.46.png)

## OCR

This image (Liquid Soap):

![lab-08-05](lab-08-cognitive-services/vision/02_OCR/bin/Debug/IMG_0175.jpeg)

Debug output:

![lab-08-06](lab-08-cognitive-services/vision/02_OCR/Screenshot%202022-04-06%20at%2023.11.43.png)


## FaceDetection

Me:

![lab-08-07](lab-08-cognitive-services/vision/03_FaceDetection/bin/Debug/IMG_0033.jpeg)

Debug output -- it tells me I'm older D:

![lab-08-08](lab-08-cognitive-services/vision/03_FaceDetection/Screenshot%202022-04-06%20at%2023.36.36.png)

![lab-08-09](lab-08-cognitive-services/vision/03_FaceDetection/Screenshot%202022-04-06%20at%2023.36.40.png)









