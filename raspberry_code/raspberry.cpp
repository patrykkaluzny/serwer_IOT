////////////////////////////////////////////////////////////////////////////
//
//  This file is part of RTIMULib
//
//  Copyright (c) 2014-2015, richards-tech, LLC
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy of
//  this software and associated documentation files (the "Software"), to deal in
//  the Software without restriction, including without limitation the rights to use,
//  copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
//  Software, and to permit persons to whom the Software is furnished to do so,
//  subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//  INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
//  PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//  HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//  OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//  SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


#include "RTIMULib.h"
#include <iostream>
#include <string.h>
#include <stdio.h>
#include <unistd.h>


int main(int argc, char *argv[])
{
    
	
	
	 int out = open("cout.log", O_RDWR|O_CREAT|O_APPEND, 0600);
    if (-1 == out) { perror("opening cout.log"); return 255; }

    int err = open("cerr.log", O_RDWR|O_CREAT|O_APPEND, 0600);
    if (-1 == err) { perror("opening cerr.log"); return 255; }

    int save_out = dup(fileno(stdout));
    int save_err = dup(fileno(stderr));

    if (-1 == dup2(out, fileno(stdout))) { perror("cannot redirect stdout"); return 255; }
    if (-1 == dup2(err, fileno(stderr))) { perror("cannot redirect stderr"); return 255; }

   int sampleCount = 0;
    int sampleRate = 0;
    uint64_t rateTimer;
    uint64_t displayTimer;
    uint64_t now;

    //  using RTIMULib here allows it to use the .ini file generated by RTIMULibDemo.
	
	 

    RTIMUSettings *settings = new RTIMUSettings("RTIMULib");

    RTIMU *imu = RTIMU::createIMU(settings);
    RTPressure *pressure = RTPressure::createPressure(settings);
    RTHumidity *humidity = RTHumidity::createHumidity(settings);

    if ((imu == NULL) || (imu->IMUType() == RTIMU_TYPE_NULL)) {
        //printf("No IMU found\n");
        exit(1);
    }

    //  This is an opportunity to manually override any settings before the call IMUInit

    //  set up IMU

    imu->IMUInit();

    //  this is a convenient place to change fusion parameters

    imu->setSlerpPower(0.02);
    imu->setGyroEnable(true);
    imu->setAccelEnable(true);
    imu->setCompassEnable(true);

    //  set up pressure sensor

    if (pressure != NULL)
        pressure->pressureInit();

    //  set up humidity sensor

    if (humidity != NULL)
        humidity->humidityInit();

    //  set up for rate timer

    rateTimer = displayTimer = RTMath::currentUSecsSinceEpoch();
	
	

    fflush(stdout); close(out);
    fflush(stderr); close(err);

    dup2(save_out, fileno(stdout));
    dup2(save_err, fileno(stderr));

    close(save_out);
    close(save_err);

    
	RTIMU_DATA imuData = imu->getIMUData();
	for (int i=1;i<argc;i++){
		int opt;
		opt = getopt(argc,argv,"pht:");
		switch(opt){
		case 'p':
			if (pressure != NULL)
			{
				pressure->pressureRead(imuData);
				printf("%4.1f",imuData.pressure);                           
			}
			break;
		case 'h':
			if (pressure != NULL)
			{
				pressure->pressureRead(imuData);
				printf("%4.1f", RTMath::convertPressureToHeight(imuData.pressure));
			}
			break;
		case 't':
			printf("%4.1f", imuData.temperature);  
			break;
		default:
			
			break;
		}
	
	}
	
    //  now just process data

   
}

