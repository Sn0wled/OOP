/* 2018 ReVoL Primer Template */
/* class.h */
#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <assert.h>
#include <stdio.h>
#include <math.h>
#include <string.h>
#include <iostream>
using namespace std;

class lamp {
protected:
	int state;
public:
	lamp() : state(1) {}
	void set(int val) {
		state = val;
	}
	int get() {
		return state;
	}
};

class colorlamp {
	int state, color;
public:
	colorlamp() : state(1), color(2) {}
};

class cola : public lamp {
	int color;
public:
	cola() : color(2) {}
	/*void set(int val) {
		lamp::set(val);
	}
	int get() {
		return lamp::get();
	}*/
};

class Vehicle {
private:
	int wheels;
	string brand;
	string model;
public:
	virtual void drive() {
		cout << "Едем" << endl;
	}
	Vehicle(int wheels, string brand, string model): wheels(wheels), brand(brand), model(model) {}
	string get_brand() {
		return brand;
	}
	string get_model() {
		return model;
	}
};

class Bicycle : public Vehicle {
public:
	Bicycle(string brand, string model) : Vehicle(2, brand, model) {}
	void drive() {
		cout << "Дзынь дзынь" << endl;
	}
};

class Car : public Vehicle{
private:
	int state;
public:
	void turn_on() {
		if (state == 0) {
			cout << "Машина завелась" << endl;
			state = 1;
		}
		else {
			cout << "Машина уже заведена" << endl;
		}
	}
	void turn_off() {
		if (state == 0) {
			cout << "Машина уже заглушена" << endl;
		}
		else {
			cout << "Машина заглохла" << endl;
			state = 1;
		}
	}
	Car(string brand, string model) : Vehicle(4, brand, model), state(0) {}
	void drive() {
		if (state != 0) cout << "Врум врум" << endl;
	}
};

class Lada : public Car {
public:
	Lada(string model) : Car("Lada", model) {}
};

class Mersedes : public Car {
public:
	Mersedes(string model) : Car("Mersedes", model) {}
};


//12
class point {
private:
	int x, y;
public:
	point() : x(0), y(0) {}
	void move(int x, int y) {
		this->x = x;
		this->y = y;
	}
	void get_pos() {
		cout << "x = " << x << ", y = " << y << endl;
	}
};

class flyla : public lamp, public point {
};