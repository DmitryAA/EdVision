module.exports = {
	state: {
		user: void 0,
	},

	mutations: {
		login: (state, value) => {
			state.user = value;
		},
	}
};