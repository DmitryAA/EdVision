<template>
	<header v-bem>
		<div class="row">
			<div v-bem.logo><router-link to="/">EdVision</router-link></div>
			<nav v-bem.menu>
				<router-link to="/universities">Университеты</router-link>
				<router-link to="/user">Кабинет</router-link>
			</nav>
			<div v-bem.user>Привет, {{ username }}</div>
		</div>
	</header>
</template>

<script>
	export default {
		name: 'top',
		computed: {
			username: function() {
				return this.$store.state.user !== void 0 ? this.$store.state.user : 'noname';
			}
		}
	};
</script>
