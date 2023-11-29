/* 2018 ReVoL Primer Template */
/* class.h */
#pragma once
#define _CRT_SECURE_NO_WARNINGS
const int MAX_GARLAND = 4;
#include <assert.h>
#include <stdio.h>
#include <math.h>
#include <string.h>
#include <iostream>
using namespace std;

// Просто лампочка
class lamp {
protected:
	int state;
public:
	lamp() : state(1) {}
	void set(int value) {
		state = value;
	}
	virtual int get() {
		return state;
	}
};

// Цветная лампочка
class colorlamp {
	int state, color;
public:
	colorlamp() : state(1), color(2) {}
};

class cola : public lamp {
	int color;
public:
	cola() : color(2) {}
	/*void set(int value) {
		lamp::set(value);
	}
	int get(){
		return lamp::get();
	}*/
	int get() {
		if (state != 0) return color;
		return 0;
	}

	void setc(int value) {
		color = value;
	}
	int getc() {
		return color;
	}
};


class garland
{
protected:
	lamp* g[MAX_GARLAND];
	int count;
public:
	garland() : count(0) {}
	~garland() {}

	void add(lamp* a) {
		assert(count < MAX_GARLAND);
		g[count++] = a;
	}
	void set(int value) {
		for (int i = 0; i < count; i++) {
			g[i]->set(value);
		}
	}

	void show() {
		for (int i = 0; i < count; i++)
		{
			cout << g[i]->get();
		}
		cout << endl;
	}
};

class color {
	int state;
public:
	color() : state(0) {}
	int getc() {
		return state;
	}
	void setc(int v) {
		state = v;
	}
};

class micola : public cola, public color {

};

// 11 вопрос

class vehicle {
	int position;
	int speed;
	int max_speed;
	int speed_plus;
	int speed_minus;
public:
	vehicle(int max_speed, int sp_plus, int sp_minus, int sp_max) : position(0), speed(0), max_speed(max_speed), speed_plus(sp_plus), speed_minus(sp_minus) {}

	void move() {
		position += speed;
	}

	int get_pos(){
		return position;
	}

protected:
	void speed_up(int val) {
		if (speed + val < max_speed) speed += val;
	}

	void speed_down(int val) {
		if (speed >= speed_minus) speed -= val;
	}
};

class bicycle : public vehicle {
public:
	bicycle(int wheels) : wheels(wheels), vehicle(max_speed) {}
	void pedaling() {
		speed_up(speed_plus);
	}
	void brake() {
		speed_down(speed_minus);
	}
};

class car : public vehicle {

};

class lada : public car {

};

class mersedes : public car {

};