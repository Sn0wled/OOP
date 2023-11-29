/**
 * Project PaintApplicatioin
 */


#ifndef _FIGURE_H
#define _FIGURE_H

class figure {
public: 
    
virtual void draw() = 0;
    
/**
 * @param a
 * @param b
 */
void figure(int a, int b);
protected: 
    int x = 0;
    int y = 0;
};

#endif //_FIGURE_H