import main from 'component-vue/mainPage';
import universities from 'component-vue/universities';
import university from 'component-vue/university';
import user from 'component-vue/user';
import department from 'component-vue/department';
import companies from 'component-vue/companies';
import company from 'component-vue/company';
import projects from 'component-vue/projects';
import project from 'component-vue/project';
import direction from 'component-vue/direction';
import student from 'component-vue/student';
import portfolio from 'component-vue/portfolio';

module.exports = [
	{ path: '/', component: main },
	{ path: '/universities', component: universities },
	{ path: '/university/:id', component: university },
	{ path: '/user/', component: user },
	{ path: '/department/:id', component: department },
	{ path: '/companies/', component: companies },
	{ path: '/company/:id', component: company },
	{ path: '/projects/', component: projects },
	{ path: '/project/:id', component: project },
	{ path: '/direction/:id', component: direction },
	{ path: '/student/:id', component: student },
	{ path: '/student/:id/portfolio', component: portfolio },
];